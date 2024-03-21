namespace Domain.Entities;

public class ProductCategory : BaseEntity
{
    public virtual int ProductId {  get; set; }
    public virtual Product Product { get; set; } = null!;
    public virtual int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
