namespace Domain.Entities
{
    public class Favourite : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
