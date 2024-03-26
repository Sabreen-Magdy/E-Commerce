namespace Domain.Entities
{
    public class Color : BaseEntity
    {
        public string Code { get; set; } 
        public string Name { get; set; }

        // To use in Filter Products By Color and Reduce Join
        public ICollection<ColoredProduct> ColoredProducts { get; set; } = null!;
    }
}
