using Contract;
using Contract.Favorite;
using Domain.Entities;
using System.Diagnostics;

namespace Services.Extenstions;

public static class FavouriteExtenstion
{
    public static FavoriteDto ToFavoriteDto(this Favourite fav)
    {
        if (fav == null)
            throw new ArgumentNullException(nameof(fav));
        string? image = fav.Product?.ColoredProducts?.FirstOrDefault()?.Image;
        return new()
        {
            Id = fav.Id,
            CustomerId= fav.CustomerId,
            ProductId = fav.ProductId,
            Image = image,
            Name = fav.Product.Name,
            Description=fav.Product.Description,
            Price=fav.Product.TotalPrice
        };
}
    public static List<FavoriteDto> ToFavoriteDto(this List<Favourite> favourites)
    {
        if (favourites == null)
            throw new ArgumentNullException(nameof(favourites));

        var ItemDtos = new List<FavoriteDto>();
        foreach (var item in favourites)
            ItemDtos.Add(item.ToFavoriteDto());

        return ItemDtos;
    }
    public static Favourite ToFavoriteEntity(this FavoriteDto favDto)
    {
        if (favDto == null)
            throw new ArgumentNullException(nameof(favDto));
        return new()
        {
            CustomerId = favDto.CustomerId,
            ProductId = favDto.ProductId,
        };
}

}
