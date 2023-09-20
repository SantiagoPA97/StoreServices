using StoreServices.API.ShoppingCart.RemoteModel;

namespace StoreServices.API.ShoppingCart.Interfaces
{
    public interface IBooksService
    {
        Task<(bool result, Book book, string errorMessage)> GetBook(Guid BookID);
    }
}
