namespace Domain.Entities
{
    public class CartItem:BaseEntity
    {

        public int Quantity { get; set; }
        public double TotalPrice { 
            get {
                return Quantity * this.ProductVarient.UnitPrice;
            } }

        // Foreign key to reference the cart
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;
        // Foreign key to reference the product
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public ProductVarient ProductVarient { get; set; } = null!;
    }
}
