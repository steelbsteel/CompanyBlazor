using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.Design;

namespace BuildingCompany.Data
{
    public class MongoDb
    {
        public User? currentUser;
        public Developer? currentDeveloper;
        public Projector? currentProjector;
        public Customer? currentCustomer;

        static MongoClient client = new MongoClient("mongodb://localhost");
        static IMongoDatabase database = client.GetDatabase("BuildingCompany");
        public static void AddProjectToDataBase(Project project)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Project>("ProjectsCollection");
            collection.InsertOne(project);
        }

        public List<Project> GetProjects()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Project>("ProjectsCollection");
            return collection.Find(new BsonDocument()).ToList();
        }
        public static void AddCustomerToDataBase(Customer customer)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Customer>("CustomerCollection");
            collection.InsertOne(customer);
        }

        public static void AddProjectorToDataBase(Projector projector)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Projector>("ProjectorCollection");
            collection.InsertOne(projector);
        }
        public static void AddDeveloperToDataBase(Developer developer)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Developer>("DeveloperCollection");
            collection.InsertOne(developer);
        }

        public static void AddUserToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<User>("UserCollection");
            collection.InsertOne(user);
        }

        public void UpdateCustomer(Customer user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var filter = Builders<Customer>.Filter.Eq("Login", user.Login);
            var collection = database.GetCollection<Customer>("CustomerCollection");
            collection.ReplaceOne(filter, user);
        }

        public void UpdateDeveloper(Developer user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var filter = Builders<Developer>.Filter.Eq("Login", user.Login);
            var collection = database.GetCollection<Developer>("DeveloperCollection");
            collection.ReplaceOne(filter, user);
        }

        public void UpdateProjector(Projector user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var filter = Builders<Projector>.Filter.Eq("Login", user.Login);
            var collection = database.GetCollection<Projector>("ProjectorCollection");
            collection.ReplaceOne(filter, user);
        }

        public List<Projector> GetProjectorsList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Projector>("ProjectorCollection");
            return collection.Find(new BsonDocument()).ToList();
        }

        public List<Developer> GetDevelopersList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Developer>("DeveloperCollection");
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
