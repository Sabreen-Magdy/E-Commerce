using Contract;
using Domain.Entities;

namespace Services.Extenstions
{
    public static class ColoredProductExtenstion
    {
        public static List<int> GetIds(this List<ColoredProduct> coloredProducts)
        {
            if (coloredProducts == null)
                throw new ArgumentNullException(nameof(coloredProducts));

            var ids = new List<int>();

            foreach (var coloredProduct in coloredProducts)
                ids.Add(coloredProduct.Id);

            return ids;
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
                });

            return coloredProducts;
        }

        public static ColoredProuctDto ToColoredProductDto(this ColoredProduct productColored)
        {
            if (productColored == null)
                throw new ArgumentNullException(nameof(productColored));

            return new
            (
                Id: productColored.Id,
                ColorCode: productColored.Color.Code,
                ColorName: productColored.Color.Name,
                Image: productColored.Image
            );
        }
        public static List<ColoredProuctDto> ToColoredProductDto
            (this List<ColoredProduct> productColoreds)
        {
            if (productColoreds == null)
                throw new ArgumentNullException(nameof(productColoreds));

            var coloredProductDtos = new List<ColoredProuctDto>();

            foreach (var item in productColoreds)
                coloredProductDtos.Add(item.ToColoredProductDto());

            return coloredProductDtos;
        }
    }
}
