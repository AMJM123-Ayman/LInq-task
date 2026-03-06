using Microsoft.EntityFrameworkCore;
using BookstoreSystem.Models;

namespace BookstoreSystem
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ضع نص الاتصال بقاعدة البيانات الخاص بك هنا
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookstoreDb;Trusted_Connection=True;");
        }
    }
}