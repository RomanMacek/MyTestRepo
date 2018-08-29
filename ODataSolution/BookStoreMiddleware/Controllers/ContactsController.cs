using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        [EnableQuery(AllowedFunctions = AllowedFunctions.All, AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Get([FromODataUri] int key)  // /contacts/contacts(1)
        {
            var item = await ContactsRepo.Find(key);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetCustById(string id) //http://localhost:2459/api/contacts/getcustbyid/11
        {
            var result = "abcde";
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
        public async Task<IActionResult> Post([FromBody]Contact contact)  // /contacts/contacts(1)
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