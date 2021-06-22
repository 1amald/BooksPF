using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GridFS;

namespace BooksPF.Models
{
    public class BookFile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public GridFSBucket File { get; set; }
    }
}
