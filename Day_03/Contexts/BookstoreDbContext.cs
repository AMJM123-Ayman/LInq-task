using BookstoreSystem.Models; // تأكد من استدعاء مجلد النماذج الذي أنشأناه سابقاً
using Microsoft.EntityFrameworkCore;

namespace BookstoreSystem.Contexts
{
    // 1. Inherit from DbContext
    public class BookstoreDbContext : DbContext
    {
        // 4. Define a DbSet<T> for each entity class
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        // 2. Override OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 3. Use the provided connection string
            optionsBuilder.UseSqlServer("Server=.;Database=BookstoreDB;Trusted_Connection=True;TrustServerCertificate=True;");

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title).IsRequired().HasMaxLength(150);
                entity.Property(b => b.Price).HasColumnType("decimal(18,2)");
                entity.Property(b => b.PublishedDate).IsRequired(false); // Optional
            });
        }
    }
    }
}