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


    //    [Route("ABCD")]  ... => /ABCD/DejmiCustSViceParametry(2,bbb)
    [Route("[controller]")]  
//    [ODataRoutePrefix("values")]
    public class ContactsController : ODataController
    {
        public IContactsRepository ContactsRepo { get; set; }

        private ContactsContextMem _dbMem;
        private ContactsContextDb.ContactsContext _db;

        public ContactsController(ContactsContextDb.ContactsContext context)
        {
            _db = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var contactList = await ContactsRepo.GetAll();
            //var contactList = _dbMem.Contacts;
            //var contactList = ContactsRepo.GetAllBase();
            var aaa = _db.Contacts;
            return Ok(contactList);
        }

        //[Microsoft.AspNetCore.Mvc.HttpGet]
        //[EnableQuery]
        //public async Task<IActionResult> Get([FromODataUri] int key) // .../contacts/contacts/2
        //{
        //    var id = 1;
        //    var item = await ContactsRepo.Find(key);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}

        [HttpGet("DejmiCust")]   //        [ODataRoute("DejmiCustById")]
        [ODataRoute]
        public IActionResult DejmiCust() // contacts/contacts/ContactsService.DejmiCustById
        {
            var result = _db.Contacts;
            return Ok(result);
        }

        // /contacts/DejmiCustSParametrem(PrvniParam=11)
        [Microsoft.AspNetCore.Mvc.HttpGet("DejmiCustSParametrem(PrvniParam={prvniParam})")]
        [EnableQuery]
        public IActionResult DejmiCustSParametrem(int prvniParam)
        {
            var result = _db.Contacts.Where(x => x.Id == prvniParam);
            return Ok(result);
        }

        // /contacts/DejmiCustSParametremShort(11)
        [Microsoft.AspNetCore.Mvc.HttpGet("DejmiCustSParametremShort({prvniParam:int})")]
        [EnableQuery]
        public IActionResult DejmiCustSParametremShort(int prvniParam)
        {
            var result = _db.Contacts.FirstOrDefault(x => x.Id == prvniParam);
            return Ok(result);
        }

        // /contacts/DejmiCustSViceParametry(456,789)
        // /contacts/DejmiCustSViceParametry(2,bbb)
        [Microsoft.AspNetCore.Mvc.HttpGet("DejmiCustSViceParametry({prvniParam},{druhyParam})")]
        [EnableQuery]
        public IActionResult DejmiCustSViceParametry(int prvniParam, string druhyParam)
        {
            var result = _db.Contacts.Where(x => x.Id == prvniParam);
            return Ok(result);
        }

        // /contacts/DejmiCustSViceParametry2(456,789)
        [Microsoft.AspNetCore.Mvc.HttpGet("DejmiCustSViceParametry2({prvniParam},{druhyParam})")]
        [EnableQuery]
        public IActionResult DejmiCustSViceParametry2(int prvniParam, int druhyParam)
        {
            var result = new List<int>() { prvniParam, druhyParam };
            return Ok(result);
        }

        // /contacts/pridejzaznam(abcd)
        [HttpPost("PridejZaznam({vstupHodnota})")]
        public IActionResult PridejZaznam(string vstupHodnota)
        {

            return Ok($"Parametr: {vstupHodnota}");
        }

        //  [HttpPost("PridejZaznamComplet({contact})")]
        //  [EnableQuery(AllowedFunctions = AllowedFunctions.All, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[HttpPost("{contact}")]
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact) // public IActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]Contact contact)  // /contacts/contacts(1)
        {
            //var item = await ContactsRepo.Find(contact.Id);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            return Ok("XXXXX");
        }

        [HttpPut] //  [AcceptVerbs("PUT")]      
        public IActionResult Put( Contact contact)
        {
            return Ok("XXXXX");
        }

    }
}