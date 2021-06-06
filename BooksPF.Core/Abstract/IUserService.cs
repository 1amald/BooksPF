using BooksPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksPF.Core.Abstract
{
    public interface IUserService
    {
        public Task<User> GetUser(string login, string password);
        public Task<User> AddUser(User user);
    }
}
