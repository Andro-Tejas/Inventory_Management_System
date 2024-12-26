using MongoDB.Driver;

namespace InventortManagement.Utils
{
    public class MongoConnection
    {
        private readonly IMongoDatabase _database;

        public MongoConnection(string connectionString,string databaseName){
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(String collectionName){
            return _database.GetCollection<T>(collectionName);
        }
    }
}