using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Loan
    {
        public int BookId { get; set; }     // Foreign Key & Composite Primary Key
        public int BorrowerId { get; set; } // Foreign Key & Composite Primary Key
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; } // علامة الـ ? تعني أن التاريخ يمكن أن يكون Null (لم يتم الترجيع بعد)

        // Navigation Properties
        public virtual Book Book { get; set; } = default!;
        public virtual Borrower Borrower { get; set; } = default!;
    }
}
