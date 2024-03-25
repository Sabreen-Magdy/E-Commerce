using Contract;
using Domain.Entities;
using Services.DataServices;

namespace Services.Extenstions;

public static class ProductVarientExtenstion
{
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
        {
            productVariants[i].ColorId = ids[i];
        }
    }

    public static List<ProductVarient> ToProductVariantEntity
        (this List<ProductVariantNewDto> productVariants, List<int> ids)
    {
        if (productVariants == null)
            throw new ArgumentNullException(nameof(productVariants));

        var productVariantsEntity = new List<ProductVarient>();

        productVariants.FillIds(ids);

        return productVariants.Select(pv => pv.ToProductVariantEntity()).ToList();
    }
    public static ProductVarient ToProductVariantEntity
       (this ProductVariantNewDto productVariant)
    {
        if (productVariant == null)
            throw new ArgumentNullException(nameof(productVariant));

        return new()
        {
            Discount = productVariant.Discount,
            ColorId = productVariant.ColorId,
            ProductId = productVariant.ProductId,
            Quantity = productVariant.Quantity,
            SizeId = productVariant.SizeId,
            UnitPrice = productVariant.UnitPrice
        };
    }

    //public static ProductVarient ToProductVariantEntity
    //   (this ProductVariantDto productVariantdto)
    //{
    //    if (productVariantdto == null)
    //        throw new ArgumentNullException(nameof(productVariantdto));

    //    return new()
    //    {
    //        Id = productVariantdto.Id,
    //        UnitPrice = productVariantdto.Price,
    //        Discount = productVariantdto.Discount,
    //        Quantity= productVariantdto.Quantity,
            
    //    };
    //}

    public static ProductVariantDto ToProductVariantDto
   (this ProductVarient productVariant)
    {
        if (productVariant == null)
            throw new ArgumentNullException(nameof(productVariant));

        var coloredProduct = productVariant.ColoredProduct.ToColoredProductDto();
        return new()
        {
            Id = productVariant.Id,
            Discount = productVariant.Discount,
            Code = coloredProduct.ColorCode,
            Price = productVariant.Price,
            Quantity = productVariant.Quantity,
            Size = productVariant.Size.Name
        };
    }

    public static List<ProductVariantDto> ToProductVariantDto(this List<ProductVarient> productVariants)
    {
        if (productVariants == null)
            throw new ArgumentNullException(nameof(productVariants));

        return productVariants.Select(pv => pv.ToProductVariantDto()).ToList();
    }
}
