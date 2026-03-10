namespace Day_04.Models.Ecommerce
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation Property: علاقة (One-to-Many) مع الطلبات
        // العميل الواحد يمكنه القيام بعدة طلبات
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}