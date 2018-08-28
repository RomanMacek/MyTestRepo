using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreMiddleware.Models;
using BookStoreMiddleware.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMiddleware.Contexts
{
    public class ContactsContextDb
    {
        public class ContactsContext : DbContext
        {
            public DbSet<Contact> Contacts { get; set; }

            public ContactsContext() { }

            public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
            {
            }

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    //modelBuilder.Entity<Contacts>().OwnsOne(c => c.Id);
            //    modelBuilder.Entity<Contact>().HasIndex(c => c.Id);
            //}
        }
    }
}
