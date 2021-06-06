using BooksPF.Core.Abstract;
using BooksPF.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BooksPF.Core.Mongo
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> users;
        public UserService(IDbClient dbClient)
        {
            users = dbClient.GetUsersCollection();
        }
        public async Task<User> AddUser(User user)
        {
            await users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> GetUser(string login, string password)
        {
            var user = await users.Find(u => u.UserName == login && u.Password == password).FirstOrDefaultAsync();
            return user;
        }
    }
}
