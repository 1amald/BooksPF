using BooksPF.Models;
using System.Threading.Tasks;

namespace BooksPF.Core.Abstract
{
    public interface IUserService
    {
        public Task<User> AuthentificateUser(string login,string password);
        public Task<User> AddUser(User user);
        public Task<bool> UserExist(string login);
    }
}
