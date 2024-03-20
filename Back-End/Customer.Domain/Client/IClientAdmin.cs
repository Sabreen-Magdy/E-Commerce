
namespace Customer.Domain.Client
{
    public interface IClientAdmin
    {
        IFavouriteClient FavouriteClient { get; }
        IOrderClient OrderClient { get; }
        ICartClient CartClient { get; }
    }
}
