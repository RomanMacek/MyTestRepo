using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreMiddleware.Models;
using BookStoreMiddleware.Repository;

namespace BookStoreMiddleware.Interface
{
    public interface IContactsRepository
    {
        Task Add(Contact item);
        IEnumerable<Contact> GetAllBase();
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Find(int key);
        Task Remove(string Id);
        Task Update(Contact item);

        bool CheckValidUserKey(string reqkey);
    }
}
