namespace Day_04.Models.Ecommerce
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; } // Foreign Key

        // Navigation Properties
        // الطلب يخص عميل واحد فقط (Many-to-One)
        public virtual Customer Customer { get; set; }

        // الطلب يحتوي على عدة منتجات (عبر جدول التفاصيل)
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}