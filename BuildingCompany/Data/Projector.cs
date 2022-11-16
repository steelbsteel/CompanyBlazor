using MongoDB.Bson.Serialization.Attributes;

namespace BuildingCompany.Data
{
    [BsonIgnoreExtraElements]
    public class Projector : User
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
        public string? DirectorFullName { get; set; }
        [BsonIgnoreIfNull]
        public string? EngineerFullName { get; set; }

        public Projector(User user,
                         string _designationPrj,
                         string _OGRNPrj,
                         string _TINPrj,
                         string _KPPPrj,
                         string _addressPrj,
                         string _directorFullNamePrj,
                         string _engineerFullNamePrj)
        {
            Login = user.Login;
            Password = user.Password;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = "Projector";
            Designation = _designationPrj;
            OGRN = _OGRNPrj;
            TIN = _TINPrj;
            Address = _addressPrj;
            DirectorFullName = _directorFullNamePrj;
            EngineerFullName = _engineerFullNamePrj;
            KPP = _KPPPrj;
            
        }
    }
}
