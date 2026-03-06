using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreSystem.Models
{
    public class Author
    {
        [Key] // يحدد هذا الحقل كـ Primary Key
        public int Id { get; set; }

        [Required] // يجعل هذا الحقل مطلوباً (Not Null)
        [MaxLength(100)] // يحدد الحد الأقصى لطول النص بـ 100 حرف
        public string Name { get; set; }

        // string? تعني أن الحقل اختياري (Nullable)
        public string? Country { get; set; }

        [Table("Writers")] // تغيير اسم الجدول إلى Writers
        public class Author
        {
            [Key]
            public int Id { get; set; }

            [Required] // Name مطلوب
            [MaxLength(100)] // الحد الأقصى 100
            public string Name { get; set; }

            public string? Country { get; set; }
        }
    }
}