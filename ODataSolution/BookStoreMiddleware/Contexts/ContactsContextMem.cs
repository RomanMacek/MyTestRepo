using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStoreMiddleware.Models;
using BookStoreMiddleware.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookStoreMiddleware.Contexts
{
    public class ContactsContextMem : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactsContextMem(DbContextOptions<ContactsContextMem> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contacts>().OwnsOne(c => c.Id);
            modelBuilder.Entity<Contact>().HasIndex(c => c.Id);
                //Contacts = modelBuilder.Entity<Contacts>()
                //    .Property(prop => prop)
                //    .HasDefaultValue(new List<Contacts>());
        }
    }
}
