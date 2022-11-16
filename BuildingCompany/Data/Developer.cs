using MongoDB.Bson.Serialization.Attributes;
using System.Xml.Linq;

namespace BuildingCompany.Data
{
    [BsonIgnoreExtraElements]
    public class Developer : User
    {
        [BsonIgnoreIfNull]
        public string? Designation { get; set; }
        [BsonIgnoreIfNull]
        public string? OGRN { get; set; }
        [BsonIgnoreIfNull]
        public string? TIN { get; set; }
        [BsonIgnoreIfNull]
        public string? KPP { get; set; }
        [BsonIgnoreIfNull]
        public string? Address { get; set; }
        [BsonIgnoreIfNull]
        public string? CommitteeFullName { get; set; }

        public Developer(User user,
                        string _designationDev,
                        string _OGRNDev,
                        string _TINDev,
                        string _KPPDev,
                        string _addressDev,
                        string _CommitteeFullNameDev)
{
            Login = user.Login;
            Password = user.Password;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = "Developer";
            Designation = _designationDev;
            OGRN = _OGRNDev;
            TIN = _TINDev;
            KPP = _KPPDev;
            Address = _addressDev;
            CommitteeFullName = _CommitteeFullNameDev;
        }
    }
}
