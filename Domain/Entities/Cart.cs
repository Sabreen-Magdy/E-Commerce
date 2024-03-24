namespace Domain.Entities
{
    public class Cart:BaseEntity
    {
        public int TotalQuantity
        {
            get
            {
                return CartItems.Sum(ci => ci.Quantity);
            }
        }

        public double TotalPrice
        {
            get
            {
                return CartItems.Sum(ci => ci.TotalPrice);
            }
        }

        #region RelationShip Mapping
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<ProductVarient> ProductVarients { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = null!;
        #endregion
    }
}
