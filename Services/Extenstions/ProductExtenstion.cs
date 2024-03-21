using Contract.Product;
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
            AddingDate = DateTime.Now,
            Description = product.Description,
            Name = product.Name,
            SallerId = product.SallerId
        };
    }
    public static ColoredProduct ToColoredProductEntity(this ProductColoredNewDto productColored)
    {
        if (productColored == null)
            throw new ArgumentNullException(nameof(productColored));

        return new()
        {
            ColorId = productColored.ColorId,
            Image = productColored.Image,
            ProductId = productColored.ProductId
        };
    }
    public static List<ColoredProduct> ToColoredProductEntity
        (this List<KeyValuePair<int, string>> images, int productId)
    {
        if (images == null)
            throw new ArgumentNullException(nameof(images));

        var coloredProducts = new List<ColoredProduct>();

        foreach (var image in images)
            coloredProducts.Add(new()
            {
                ColorId = image.Key,
                Image = image.Value,
                ProductId = productId
            } );

        return coloredProducts;
    }

    public static List<int> GetIds(this List<ColoredProduct> coloredProducts)
    {
        if (coloredProducts == null)
            throw new ArgumentNullException(nameof(coloredProducts));
       
        var ids = new List<int>();

        foreach (var coloredProduct in coloredProducts)
            ids.Add(coloredProduct.Id);

        return ids;
    }

    public static void FillIds(this List<ProductVariantNewDto> productVariants
        , List<int> ids)
    {
        if (productVariants == null)
            throw new ArgumentNullException(nameof(productVariants));
        if (ids == null)
            throw new ArgumentNullException(nameof(ids));

        int len = productVariants.Count;
        if (len != ids.Count) 
            throw new IndexOutOfRangeException("2 Lists must have the Same Lenght");

        for (int i = 0; i < len; i++)
            productVariants[i].ColoredProductId = ids[i];
    }

    public static List<ProductVarient> ToProductVariantEntity
        (this List<ProductVariantNewDto> productVariants, List<int> ids)
    {
        if (productVariants == null)
            throw new ArgumentNullException(nameof(productVariants));

        var productVariantsEntity = new List<ProductVarient>();

        productVariants.FillIds(ids);
        
        foreach (var productVariant in productVariants)
            productVariantsEntity.Add(productVariant.ToProductVariantEntity());

        return productVariantsEntity;
    }
    public static ProductVarient ToProductVariantEntity
       (this ProductVariantNewDto productVariant)
    {
        if (productVariant == null)
            throw new ArgumentNullException(nameof(productVariant));

        return new()
        {
            Discount = productVariant.Discount,
            ColoredProductId = productVariant.ColoredProductId,
            Quantity = productVariant.Quantity,
            SizeId = productVariant.SizeId,
            UnitPrice = productVariant.UnitPrice
        };
    }
}
