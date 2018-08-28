using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStoreMiddleware.Contexts;
using BookStoreMiddleware.Interface;
using BookStoreMiddleware.Middleware;
using BookStoreMiddleware.Models;
using BookStoreMiddleware.Repository;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using NLog.Extensions.Logging;
using NLog.Web;

namespace BookStoreMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists")); // Za druhé, měli bychom registrovat databázový kontext pomocí 
            services.AddOData();  // ASP.NET Core OData vyžaduje některé služby registrované vpřed, aby poskytly své funkce. 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddSingleton<IContactsRepository, ContactsRepository>();
            //   services.AddTransient<IContactsRepository, ContactsRepository>();
            
            //services.AddDbContext<ContactsContextMem>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ContactsContextMem>(opt => opt.UseInMemoryDatabase("ContactsLists"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.ConfigureNLog("nlog.config");
            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseLogMiddleware();        //  app.UseMiddleware<LogMiddleware>();
       //     app.UserKeyValidationMiddleware();
            //app.UseApproachMiddleware();   //  app.UseMiddleware<AproachMiddleware>();

            app.UseMvc(b =>
            {
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();  //Přidání následujícího řádku kódu do Startup.cs umožňuje všechny možnosti dotazu OData, například $ filter, $ orderby, $ expand, atd.
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
                b.MapODataServiceRoute("contact", "contact", GetEdmModelContacts());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Press>("Presses");
            return builder.GetEdmModel();
        }

        private static IEdmModel GetEdmModelContacts()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Contact>("Contacts");
            return builder.GetEdmModel();
        }
    }
}
