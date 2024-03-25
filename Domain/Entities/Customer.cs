namespace Domain.Entities;

public class Customer : User
{
    public string? Image { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual List<Favourite>? Favourites { get; set; } 
    public List<Review> Reviews { get; set; } = null!;

    public virtual List<Order>? Orders { get; set; }
}
