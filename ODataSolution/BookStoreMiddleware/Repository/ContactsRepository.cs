using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreMiddleware.Contexts;
using BookStoreMiddleware.Interface;
using BookStoreMiddleware.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMiddleware.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactsContextDb.ContactsContext _context;

        //public ContactsRepository()
        //{

        //}

        public ContactsRepository(ContactsContextDb.ContactsContext context)
        {
            _context = context;
        }

        public async Task Add(Contact item)
        {
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();
        }


        public IEnumerable<Contact> GetAllBase()
        {      
            var result = _context.Contacts.ToList();
            return result;
        }
        public async Task<IEnumerable<Contact>> GetAll()
        {
            var result = _context.Contacts.ToListAsync();
            return await _context.Contacts.ToListAsync();
        }

        public bool CheckValidUserKey(string reqkey)
        {
            var userkeyList = new List<string>
            {
                "28236d8ec201df516d0f6472d516d72d",
                "38236d8ec201df516d0f6472d516d72c",
                "48236d8ec201df516d0f6472d516d72b"
            };

            if (userkeyList.Contains(reqkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Contact> Find(int key)
        {
            return await _context.Contacts
                .Where(e => e.Id.Equals(key))
                .SingleOrDefaultAsync();
        }

        //public async Task Remove(string Id)
        //{
        //    var itemToRemove = await _context.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == Id);
        //    if (itemToRemove != null)
        //    {
        //        _context.Contacts.Remove(itemToRemove);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task Update(Contact item)
        //{
        //    var itemToUpdate = await _context.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == item.MobilePhone);
        //    if (itemToUpdate != null)
        //    {
        //        itemToUpdate.FirstName = item.FirstName;
        //        itemToUpdate.LastName = item.LastName;
        //        itemToUpdate.IsFamilyMember = item.IsFamilyMember;
        //        itemToUpdate.Company = item.Company;
        //        itemToUpdate.JobTitle = item.JobTitle;
        //        itemToUpdate.Email = item.Email;
        //        itemToUpdate.MobilePhone = item.MobilePhone;
        //        itemToUpdate.DateOfBirth = item.DateOfBirth;
        //        itemToUpdate.AnniversaryDate = item.AnniversaryDate;
        //        await _context.SaveChangesAsync();
        //    }
        //}

    }
}
