namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
