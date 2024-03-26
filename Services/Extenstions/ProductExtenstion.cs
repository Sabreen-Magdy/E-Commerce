using Contract;
using Domain.Entities;

namespace Services.Extenstions;

public static class ProductExtenstion
{
    public static Product ToProductEntity(this ProductNewDto product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        return new()
        {
            AddingDate = DateTime.Now.AddMinutes(1),
            Description = product.Description,
            Name = product.Name,
            SallerId = product.SallerId
        };
    }
    public static List<Product> ToProductEntity(this List<ProductNewDto> products)
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));

        var Products = new List<Product>();
        foreach (var item in products)
            Products.Add(item.ToProductEntity());

        return Products;
    }

    public static ProductDto ToProductDto(this Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        var coloredProducts = product.ColoredProducts;
        var coloredProduct = coloredProducts is null? null : coloredProducts.First();

        return new()
        {
            Id = product.Id,
            Image = coloredProduct is null? "" : coloredProduct.Image,
            Name = product.Name,
            Price = product.AvgPrice  
        };
    }
    public static List<ProductDto> ToProductDto(this List<Product> products)
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));

        var ProductDtos = new List<ProductDto>();
        foreach( var item in products) 
            ProductDtos.Add(item.ToProductDto());

        return ProductDtos;
    }
}
