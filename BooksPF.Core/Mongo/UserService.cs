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
            if(await UserExist(user.Login))
            {
                return null;
            }
            await users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> AuthentificateUser(string login,string password)
        {
            var result = await users.Find(u => u.Login == login && u.Password == password).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UserExist(string login)
        {
            var result = await users.Find(u => u.Login == login).FirstOrDefaultAsync();
            return result != null;
        }
    }
}
