using BooksPF.Models;
using MongoDB.Driver;

namespace BooksPF.Core.Abstract
{
    public interface IDbClient
    {
        IMongoCollection<Book> GetBooksCollection();
        IMongoCollection<User> GetUsersCollection();
    }
}
