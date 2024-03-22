namespace Domain.Entities
{
    public class Color : BaseEntity
    {
        //public System.Drawing.Color Code { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } = null!;
    }
}
