using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Press { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
        }
    }
}