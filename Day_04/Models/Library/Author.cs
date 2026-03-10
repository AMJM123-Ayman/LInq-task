using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // Navigation Property: الكاتب الواحد له العديد من الكتب (One-to-Many)
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}