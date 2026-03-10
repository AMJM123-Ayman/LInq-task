using System;
using System.Collections.Generic;
using System.Text;

namespace Day_04.Models.Ecommerce
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property: علاقة (One-to-Many) مع المنتجات
        // القسم الواحد يحتوي على قائمة من المنتجات
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
