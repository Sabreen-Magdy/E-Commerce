using Contract;
using Domain.Entities;

namespace Services.Extenstions;

public static class FavouriteExtenstion
{
    public static ItemDto ToItemDto(this Favourite favourite)
    {
        if (favourite == null)
            throw new ArgumentNullException(nameof(favourite));

        var product = favourite.Product.ToProductDto();
        return new()
        {
            Description = favourite.Product.Description,
            Image = product.Image,
            Name = product.Name,
            Price = product.Price,
            Quantity = favourite.Product.TotalQuantity
        };
    }
    public static List<ItemDto> ToItemDto(this List<Favourite> favourites)
    {
        if (favourites == null)
            throw new ArgumentNullException(nameof(favourites));

        var ItemDtos = new List<ItemDto>();
        foreach (var item in favourites)
            ItemDtos.Add(item.ToItemDto());

        return ItemDtos;
    }
}
