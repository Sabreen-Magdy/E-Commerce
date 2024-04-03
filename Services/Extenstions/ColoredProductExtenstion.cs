using Contract;
using Domain.Entities;
using System;
using System.IO;

namespace Services.Extenstions
{

    public static class ColoredProductExtenstion
    {
        private static string SaveProductImage(int productId, int colorId, string imageBase64)
        {
            string path = "product_" + productId.ToString() + "_" + colorId.ToString() + ".png";
            Static.SaveImage(path, imageBase64);
            return path;
        }
        public static List<int> GetIds(this List<ProductColoredAddDto> coloredProducts)
        {
            if (coloredProducts == null)
                throw new ArgumentNullException(nameof(coloredProducts));

            var ids = new List<int>();

            foreach (var coloredProduct in coloredProducts)
                ids.Add(coloredProduct.ColorId);

            return ids;
        }
        public static ColoredProduct ToColoredProductEntity(this ProductColoredNewDto productColored)
        {
            if (productColored == null)
                throw new ArgumentNullException(nameof(productColored));

            string path;
            try
            {
               path = SaveProductImage(productColored.ProductId, productColored.ColorId, productColored.Image);
                return new()
                {
                    ColorId = productColored.ColorId,
                    Image = path,
                    ProductId = productColored.ProductId
                };
            }
            catch (Exception)
            {
                throw new Exception("Can not save Image");
            }

        }


        public static ColoredProduct ToColoredProductEntity(this ProductColoredAddDto productColored, int productId)
        {
            if (productColored == null)
                throw new ArgumentNullException(nameof(productColored));

            try
            {
                string path = SaveProductImage(productId, productColored.ColorId, productColored.Image);
                return new()
                {
                    ProductId = productId,
                    ColorId = productColored.ColorId,
                    Image = path,
                };
            }
            catch (Exception)
            {
                throw new Exception("Can not save Image");
            }
          
        }
        public static List<ColoredProduct> ToColoredProductEntity
            (this List<ProductColoredAddDto> images, int productId)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));

            var coloredProducts = new List<ColoredProduct>();

            foreach (var image in images)
                coloredProducts.Add(image.ToColoredProductEntity(productId)); ;

            return coloredProducts;
        }



        public static ColoredProuctDto ToColoredProductDto(this ColoredProduct productColored)
        {
            if (productColored == null)
                throw new ArgumentNullException(nameof(productColored));

            return new(
                    Id: productColored.Id,
                    ColorCode: productColored.Color.Code,
                    ColorName: productColored.Color.Name,
                    Image: productColored.Image);
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
