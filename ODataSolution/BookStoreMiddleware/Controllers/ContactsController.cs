using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreMiddleware.Contexts;
using BookStoreMiddleware.Interface;
using BookStoreMiddleware.Models;
using BookStoreMiddleware.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookStoreMiddleware.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ContactsController : ODataController
    {
        public IContactsRepository ContactsRepo { get; set; }

        //public ContactsController(IContactsRepository _repo)
        //{
        //    ContactsRepo = _repo;
        //}

        private ContactsContextMem _db;
        public ContactsController(ContactsContextMem context)
        {
            _db = context;
            var item1 = new Contact()
            {
                Id = 1,
                Company = "AAAA",
                FirstName = "BBBB",
                LastName = "CCCC"
            };

            context.Contacts.Add(item1);
            context.SaveChanges();
        }

        [EnableQuery]
        public IActionResult Get() //public async Task<IActionResult> Get()
        {
            //var contactList = await ContactsRepo.GetAll();
            var contactList = _db.Contacts;
            return Ok(contactList);
        }

        //[HttpGet("{id}", Name = "GetContacts")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var item = await ContactsRepo.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(item);
        //}

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