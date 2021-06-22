using BooksPF.Core.Abstract;
using BooksPF.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BooksPF.Core.Mongo
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> books;
        private readonly IMongoCollection<User> users;
        private readonly IMongoCollection<BookFile> files;
        private readonly IGridFSBucket bucket;
        public DbClient(IOptions<BooksPFDbConfig> options)
        {
            var client = new MongoClient(options.Value.Connection_String);
            var db = client.GetDatabase(options.Value.Database_Name);
            books = db.GetCollection<Book>(options.Value.Books_Collection_Name);
            users = db.GetCollection<User>(options.Value.Users_Collection_Name);
            bucket = new GridFSBucket(db);
            files = db.GetCollection <BookFile>(options.Value.Files_Collection_Name);
        }

        public IMongoCollection<Book> GetBooksCollection() => books;

        public IMongoCollection<BookFile> GetFilesCollection() => files;

        public IMongoCollection<User> GetUsersCollection() => users;
        public IGridFSBucket GetBucket() => bucket;
    }
}
