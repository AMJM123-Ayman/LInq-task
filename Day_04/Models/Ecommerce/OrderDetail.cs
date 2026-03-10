namespace Day_04.Models.Ecommerce
{
    public class OrderDetail
    {
        public int OrderId { get; set; }   // Composite Primary Key & Foreign Key
        public int ProductId { get; set; } // Composite Primary Key & Foreign Key
        public int Quantity { get; set; }

        // Navigation Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}