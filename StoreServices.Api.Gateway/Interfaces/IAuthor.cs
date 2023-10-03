using StoreServices.API.Gateway.Models;

namespace StoreServices.API.Gateway.Interfaces
{
    public interface IAuthor
    {
        Task<(bool result, Author author, string errorMessage)> GetAuthor(Guid authorId);
    }
}
