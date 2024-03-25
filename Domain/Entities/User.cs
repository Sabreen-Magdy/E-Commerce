namespace Domain.Entities
{
    public class User : BaseEntity 
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public virtual ICollection<Customer>? Customers { get; set; }
        public virtual ICollection<Saller>? Sallers { get; set; }

    }
}
