using BooksPF.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BooksPF.Core.Abstract
{
    public interface IDbClient
    {
        IMongoCollection<Book> GetBooksCollection();
        IMongoCollection<User> GetUsersCollection();
        IMongoCollection<BookFile> GetFilesCollection();
        IGridFSBucket GetBucket();
    }
}
