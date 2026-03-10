namespace Day_04.Models.Ecommerce
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } // Foreign Key

        // Navigation Properties
        // المنتج يتبع قسم واحد فقط (Many-to-One)
        public virtual Category Category { get; set; }

        // المنتج يمكن أن يظهر في تفاصيل طلبات كثيرة
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}