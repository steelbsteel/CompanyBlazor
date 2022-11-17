using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BuildingCompany.Data
{
    [BsonIgnoreExtraElements]
    public class Document
    {
        [BsonId] public ObjectId Id;
        [BsonIgnoreIfDefault] public string Name;
        [BsonIgnoreIfDefault] public bool IsRequired = false;
        [BsonIgnoreIfDefault] public byte[]? data;
        [BsonIgnoreIfDefault] public string FileName;
        [BsonIgnoreIfDefault] public string FileExtension;

        public Document(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
