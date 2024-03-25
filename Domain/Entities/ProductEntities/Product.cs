﻿namespace Domain.Entities;

public class Product : BaseEntity
{
    public string   Name            { get; set; } = null!;
    public string?  Description     { get; set; }
    public DateTime AddingDate      { get; set; }
    public int      NumberReviews { get; set; }
    public float AvgRate { get; set; }

    public double AvgPrice
    {
        get
        {
            if (IsColoredProductsNull())
                return 0;
            return ColoredProducts!.Average(cp => cp.TotalPrice);
        }
    }
    public double TotalPrice
    {
        get
        {
            if (IsColoredProductsNull())
                return 0;
            return ColoredProducts!.Sum(cp => cp.TotalPrice);
        }
    }
    public int TotalQuantity
    {
        get
        {
            if (IsColoredProductsNull())
                return 0;
            return ColoredProducts!.Sum(cp => cp.TotalQuntity);
        }
    }


    private bool IsColoredProductsNull() => 
        ColoredProducts != null || !ColoredProducts!.Any();

    // RelationShip Mapping
    public virtual int SallerId { get; set; }
    public virtual Saller Saller { get; set; } = null!;
    public List<Review> Reviews { get; set; } = null!;
    public ICollection<Favourite> Favourites { get; set; } = null!;


    // Reduce Join
    public ICollection<ColoredProduct> ColoredProducts { get; set; } = null!;
    public ICollection<ProductCategory> ProductCategories { get; set; } = null!;
}