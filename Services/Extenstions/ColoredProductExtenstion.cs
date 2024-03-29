﻿using Contract;
using Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Services.Extenstions
{
    public static class ColoredProductExtenstion
    {
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

        public static ColoredProduct ToColoredProductEntity(this ProductColoredAddDto productColored)
        {
            if (productColored == null)
                throw new ArgumentNullException(nameof(productColored));

            return new()
            {
                ColorId = productColored.ColorId,
                Image = productColored.Image.FileName,
                
            };
        }
        public static List<ColoredProduct> ToColoredProductEntity
            (this List<ProductColoredAddDto> images, int productId)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));

            var coloredProducts = new List<ColoredProduct>();

            foreach (var image in images)
                coloredProducts.Add(new()
                {
                    ColorId = image.ColorId,
                    Image =productId+"_"+image.ColorId+"."+image.Image.FileName.Split('.').Last(),
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
