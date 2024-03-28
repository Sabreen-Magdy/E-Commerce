namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public int Rate { get; set; }
        public string? Comment { get; set; } 
        public DateTime Date { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
