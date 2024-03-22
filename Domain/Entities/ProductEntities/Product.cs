﻿namespace Domain.Entities;

public class Product : BaseEntity
{
    public string   Name            { get; set; } = null!;
    public string?  Description     { get; set; }
    public DateTime AddingDate      { get; set; }
    public int      NumberReviews { get; set; }
    public float    AvgRate         { get; set; }

    // RelationShip Mapping
    public virtual int SallerId { get; set; }
    public virtual Saller Saller { get; set; } = null!;
    public List<Review> Reviews { get; set; } = null!;
}
