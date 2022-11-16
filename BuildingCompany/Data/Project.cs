using MongoDB.Bson.Serialization.Attributes;

namespace BuildingCompany.Data
{
    [BsonIgnoreExtraElements]
    public class Project
    {
        [BsonIgnoreIfNull]
        public string Name;

        [BsonIgnoreIfNull]
        public List<Document> Documents;

        [BsonIgnoreIfNull]
        public string type;
    }
}
