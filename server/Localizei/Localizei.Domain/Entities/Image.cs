using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Localizei.Domain.Services
{
    public class Inputs
    {
        public Image[] faceId { get; set; }
    }

    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string FaceId { get; set; }
        public string Data { get; set; }
        public int? Status { get; set; }
    }
}