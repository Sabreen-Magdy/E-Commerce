namespace Domain.Entities
{
    public class Color : BaseEntity
    {
        public System.Drawing.Color Code { get; set; }
        public string Name { get; set; } = null!;

        // To use in Filter Products By Color and Reduce Join
        public ICollection<ColoredProduct> ColoredProducts { get; set; } = null!;
    }
}
