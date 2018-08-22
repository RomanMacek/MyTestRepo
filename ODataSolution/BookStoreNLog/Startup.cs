using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
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

namespace BookStore
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
            // vestavěné injekce závislostí v konfiguraci služby.Takže změňte metodu "ConfigureServices" v třídě "Startup" 
            services.AddOData();  // ASP.NET Core OData vyžaduje některé služby registrované vpřed, aby poskytly své funkce. 
            // Knihovna poskytuje metodu rozšíření nazvanou "AddOData ()" pro registraci požadovaných služeb OData prostřednictvím vestavěné závislostí. 
            // Do třídy "Spuštění" vložte následující metody do metody "Konfigurace služeb":
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error"); // pravdepodobne presmeruje na tuto stranku pri error
            //}

            //app.UseMvc();

            // Také je třeba přidat cestu OData k registraci koncového bodu OData.
            // Přidáme cestu OData s názvem "odata" s předponou "odata" na trasách MVC a zavoláme "GetEdmModel()", 
            // abychom model Edm spojili s koncovým bodem.Takže změňte metodu "Konfigurovat ()" v třídě "Startup" jako:
            app.UseMvc(b =>
            {
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();  //Přidání následujícího řádku kódu do Startup.cs umožňuje všechny možnosti dotazu OData, například $ filter, $ orderby, $ expand, atd.
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Press>("Presses");
            return builder.GetEdmModel();
        }
    }
}
