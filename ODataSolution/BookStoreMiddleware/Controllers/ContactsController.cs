using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BookStoreMiddleware.Contexts;
using BookStoreMiddleware.Interface;
using BookStoreMiddleware.Models;
using BookStoreMiddleware.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OData.UriParser;

namespace BookStoreMiddleware.Controllers
{

    //  https://docs.microsoft.com/cs-cz/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/odata-actions-and-functions
       
        // je zde insert update select ....
       //https://docs.microsoft.com/cs-cz/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-endpoint

    //  [Route("api/[controller]")]
    //      [ApiController]
    public class ContactsController : ODataController
    {
        public IContactsRepository ContactsRepo { get; set; }

        public ContactsController(IContactsRepository _repo)
        {
            ContactsRepo = _repo;
        }

        private ContactsContextMem _dbMem;
        private ContactsContextDb.ContactsContext _db;

        //public ContactsController(ContactsContextDb.ContactsContext context)
        //{
        //    _db = context;
        //}

        //public ContactsController(ContactsContextMem context)
        //{
        //    _dbMem = context;
        //    var item1 = new Contact()
        //    {
        //        Id = 1,
        //        Company = "AAAA",
        //        FirstName = "BBBB",
        //        LastName = "CCCC"
        //    };

        //    context.Contacts.Add(item1);
        //    context.SaveChanges();
        //}

        [EnableQuery]
        public async Task<IActionResult> Get() //public async Task<IActionResult> Get()
        {
            var contactList = await ContactsRepo.GetAll();
            //var contactList = _dbMem.Contacts;
            //var contactList = ContactsRepo.GetAllBase();
            return Ok(contactList);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [EnableQuery]        
        public async Task<IActionResult> Get([FromODataUri] int key) // .../contacts/contacts/2
        {
            var id = 1;
            var item = await ContactsRepo.Find(key);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]   //        [ODataRoute("DejmiCustById")]
        public IActionResult DejmiCustById() // contacts/contacts/ContactsService.DejmiCustById
        {
            //
            var result = "abcde";
            return Ok(result);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ODataRoute("DejmiCustByIdSParametrem(NejakeId={nejakeId})")]
        public IActionResult DejmiCustByIdSParametrem([FromODataUri] int nejakeId) // .../contacts/DejmiCustByIdSParametrem(NejakeId=12)
        {
            // protoze je to v Startup.cs definovano jako "Unbound Function"
            // builder.Function("DejmiCustByIdSParametrem").Returns<string>().Parameter<int>("NejakeId");
            // a ne jako 
            // builder.EntityType<Contact>().Collection.Function("DejmiCustById").Returns<string>();
            //tak je ve volaci URL o jedno "contacts" mene

            var result = $"DejmiCustByIdSParametrem OK: {nejakeId}";
            return Ok(result);
        }

        //[HttpGet]
        //public IActionResult GetCustById(string id)
        //{
        //    var result = "abcde";
        //    return Ok(result);
        //}

        //[HttpPost]
        [EnableQuery(AllowedFunctions = AllowedFunctions.All, AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Post([Microsoft.AspNetCore.Mvc.FromBody]Contact contact)  // /contacts/contacts(1)
        {
            var item = await ContactsRepo.Find(contact.Id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] Contact item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }
        //    await ContactsRepo.Add(item);
        //    return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.MobilePhone }, item);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(string id, [FromBody] Contact item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }
        //    var contactObj = await ContactsRepo.Find(id);
        //    if (contactObj == null)
        //    {
        //        return NotFound();
        //    }
        //    await ContactsRepo.Update(item);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    await ContactsRepo.Remove(id);
        //    return NoContent();
        //}
    }
}