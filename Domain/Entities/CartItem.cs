namespace Domain.Entities
{
    public class CartItem:BaseEntity
    {

        public int Quantity { get; set; }
        public double TotalPrice { 
            get {
                return Quantity * ProductVarient.UnitPrice;
            } }

        public int State { get; set; }

        // Foreign key to reference the cart
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        // Foreign key to reference the product
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public ProductVarient ProductVarient { get; set; } = null!;
    }
}
