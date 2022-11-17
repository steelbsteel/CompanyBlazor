using BuildingCompany.Pages;
using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.ComponentModel.Design;

namespace BuildingCompany.Data
{
    public class MongoDb
    {
        public User? currentUser;
        public Developer? currentDeveloper;
        public Projector? currentProjector;
        public Customer? currentCustomer;
        public Project? currentProject;

        static MongoClient client = new MongoClient("mongodb://localhost");
        static IMongoDatabase database = client.GetDatabase("BuildingCompany");
        public static void AddProjectToDataBase(Project project)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Project>("ProjectsCollection");
            collection.InsertOne(project);
        }

        public Project SearchProject(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Project>("ProjectsCollection");
            return (collection.Find(x => x.Name == name).FirstOrDefault());
        }
        public List<Project> GetProjects()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Project>("ProjectsCollection");
            return collection.Find(new BsonDocument()).ToList();
        }

        public Developer SearchDevByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Developer>("DeveloperCollection");
            return (collection.Find(x => x.Designation == name).FirstOrDefault());
        }

        public Projector SearchPrjByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var collection = database.GetCollection<Projector>("ProjectorCollection");
            return (collection.Find(x => x.Designation == name).FirstOrDefault());
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

        public async Task UploadFileToDb(IBrowserFile file, Document document, Stream stream)
        {
            var gridFS = new GridFSBucket(database);
            await gridFS.UploadFromStreamAsync(file.Name, stream);
            document.FileName = file.Name;
            document.FileExtension =  file.Name.Split('.')[^1];
            document.data = GetByteArrayFromFile(file.Name);
        }

        public byte[] GetByteArrayFromFile(string fileName)
        {
            byte[] byteArray;
            var gridFS = new GridFSBucket(database);
            try
            {
                byteArray = gridFS.DownloadAsBytesByName(fileName);
            }
            catch
            {
                byteArray = null;
            }
            return byteArray;
        }

        public void DownloadFile(Document document)
        {
            System.IO.File.WriteAllBytes($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{document.FileName}", document.data);
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

        public void UpdateProject(Project project)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BuildingCompany");
            var filter = Builders<Project>.Filter.Eq("Name", project.Name);
            var collection = database.GetCollection<Project>("ProjectsCollection");
            collection.ReplaceOne(filter, project);
        }
    }
}
