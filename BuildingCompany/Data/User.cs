using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata;

namespace BuildingCompany.Data
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonIgnoreIfNull]
        public string Login { get; set; }
        [BsonIgnoreIfNull]
        public string Password { get; set; }
        [BsonIgnoreIfNull]
        public string Email { get; set; }
        [BsonIgnoreIfNull]
        public string PhoneNumber { get; set; }
        [BsonIgnoreIfNull]
        public string Role { get; set; }
        [BsonIgnore]
        public User? currentUser;
    }
}
