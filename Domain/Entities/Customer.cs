using Domain.Enums;

namespace Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Image { get; set; }

    public UserRole Role => UserRole.Customer;

    public List<CartItem> Cart { get; set; } = null!;
    public List<Favourite> Favourites { get; set; } = null!;
    public List<Review> Reviews { get; set; } = null!;

    public List<Order> Orders { get; set; } = null!;
}
