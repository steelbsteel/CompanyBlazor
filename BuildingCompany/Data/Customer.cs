using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace BuildingCompany.Data
{
    [BsonIgnoreExtraElements]
    public class Customer : User
    {
        [BsonIgnoreIfNull]
        public string? Name { get; set; }
        [BsonIgnoreIfNull]
        public string? Surname { get; set; }
        [BsonIgnoreIfNull]
        public string? Patronymic { get; set; }
        [BsonIgnoreIfNull]
        public string? Department { get; set; }
        [BsonIgnoreIfNull]
        public string? Post { get; set; }
        [BsonIgnoreIfNull]
        public string? NSPDirector { get; set; }
        [BsonIgnoreIfNull]
        public string? Type { get; set; }

        public Customer (User user,
                        string _nameCust,
                        string _surnameCust,
                        string _patronymicCust,
                        string _departmentCust,
                        string _postCust,
                        string _NSPDirectorCust,
                        string _typeCust)
        {
            Login = user.Login;
            Password = user.Password;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = "Customer";
            Name = _nameCust;
            Surname = _surnameCust;
            Patronymic = _patronymicCust;
            Department = _departmentCust;
            Post = _postCust;
            NSPDirector = _NSPDirectorCust;
            Type = _typeCust;
        }
    }
}
