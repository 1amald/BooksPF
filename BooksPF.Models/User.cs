using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksPF.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string login,string password)
        {
            Login = login;
            Password = password;
        }
    }
}
