namespace Domain.Entities
{
    public class Size : BaseEntity
    {
        public string Name { get; set; } = null!;
        
        // Reduce Join
        public ICollection<ProductVarient>? Varients { get; set; }
    }
}
