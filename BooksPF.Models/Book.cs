using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksPF.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string HolderName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }

        public Book(string title,string author,bool isPublic)
        {
            Title = title;
            Author = author;
            IsPublic = isPublic; 
        }
    }
}
