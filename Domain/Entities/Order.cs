namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderedDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public int State { get; set; }
        public double TotalCost { get; set; }
        public string CustomerAddress { get; set; } = null!;

        #region Relationship Mapping

     // Use Configuration Ya Sama ! 
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } = null!;

        public ICollection<ProductVarientBelongToOrder>? ProductBelongToOrders { get; set; } = null!;

        #endregion



    }
}
