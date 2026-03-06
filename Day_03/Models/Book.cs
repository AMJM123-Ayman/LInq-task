using System;
using System.ComponentModel.DataAnnotations;

namespace BookstoreSystem.Models
{
    public class Book
    {

        /*Q1: Why did the property "Id" become a Primary Key without any explicit configuration?

Answer: لأن EF Core يتبع "اصطلاح التسمية" (Convention)؛ حيث يعتبر أي خاصية باسم Id أو [ClassName]Id هي المفتاح الأساسي تلقائياً.

Q2: Why is "Country" nullable in the database while "Price" is not?

Answer: لأن Country من نوع string (Reference Type) وهو يقبل القيمة null افتراضياً في C#، بينما Price من نوع decimal (Value Type) وهو غير قابل لـ null ما لم يتم تعريفه كـ decimal?.*/
        [Key] // يحدد هذا الحقل كـ Primary Key
        public int Id { get; set; }

        [Required] // يجعل هذا الحقل مطلوباً (Not Null)
        [MaxLength(150)] // يحدد الحد الأقصى لطول النص بـ 150 حرف
        public string Title { get; set; }

        [Required] // يجعل هذا الحقل مطلوباً
        public decimal Price { get; set; }

        // DateTime? تعني أن الحقل اختياري (Nullable)
        public DateTime? PublishedDate { get; set; }
    }
}