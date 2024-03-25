using Domain.Enums;

namespace Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public UserRole Role => UserRole.Customer;

    public string? Image { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual List<Favourite>? Favourites { get; set; } 
    public List<Review> Reviews { get; set; } = null!;

    public virtual List<Order>? Orders { get; set; }
}
