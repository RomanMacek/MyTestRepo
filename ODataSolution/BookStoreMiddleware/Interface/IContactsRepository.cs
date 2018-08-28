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
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Find(string key);
        Task Remove(string Id);
        Task Update(Contact item);

        bool CheckValidUserKey(string reqkey);
    }
}
