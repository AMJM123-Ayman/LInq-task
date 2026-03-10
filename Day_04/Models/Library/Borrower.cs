using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }

        // علاقة Many-to-Many مع الكتب عبر جدول الـ Loan
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}