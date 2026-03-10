using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AuthorId { get; set; } // Foreign Key

        // Navigation Property: الكتاب يتبع مؤلف واحد
        public virtual Author Author { get; set; } = default!;

        // علاقة Many-to-Many مع المستعيرين عبر جدول الـ Loan
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
