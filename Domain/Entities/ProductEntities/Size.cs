namespace Domain.Entities
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }
        
        // Reduce Join
        public ICollection<ProductVarient> Varients { get; set; } = null!;
    }
}
