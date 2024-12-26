using InventortManagement.Models;
using InventortManagement.Utils;
using MongoDB.Driver;

namespace InventortManagement.Repository
{
    public class MongoRepository : IMongoRepository
    {
       private readonly IMongoCollection<Product> _collection;

       private readonly IMongoCollection<Inventory> _inventoryCollection;


        public MongoRepository()
        {
            var mongoConnection = new MongoConnection("mongodb://localhost:27017/", "InventoryManagement");
            _collection = mongoConnection.GetCollection<Product>("Products");
            _inventoryCollection = mongoConnection.GetCollection<Inventory>("Inventory");
        }

        // Listing all Products
        public async Task<List<Product>> listAllProducts()
        {
            try
            {

                var products = await _collection.Find(p => true).ToListAsync();

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Method for adding new Product to List
        public async Task<string> addNewProduct(Product product)
        {

            try
            {
                await _collection.InsertOneAsync(product);

                return "Product added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        // Method for updating existing Product
        public async Task<string> updateExistingProduct(Product product)
        {

            try
            {

                var filter = Builders<Product>.Filter.Eq(p => p.Name, product.Name);

                await _collection.ReplaceOneAsync(filter, product);

                return "Product updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        // Method for deleting existing Product
        public void deleteExistingProduct(string productId)
        {
            try
            {


                var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);

                _collection.DeleteOne(filter);

            }
            catch (Exception ex)
            {

            }
        }


        // Inventory Management
        // Method for adding new Inventory(stocks) for product
        public string addNewInventory(Inventory inventory)
        {
            try
            {

                var filter = Builders<Inventory>.Filter.Eq(p => p.Id, inventory.Id);

                var productExistingInventory = _inventoryCollection.Find(filter).FirstOrDefaultAsync().Result;

                if (productExistingInventory != null)
                {
                    inventory.Quantity = productExistingInventory.Quantity + inventory.Quantity;
                }
                else
                {
                    inventory.Quantity = inventory.Quantity;
                }

                _inventoryCollection.InsertOne(inventory);

                return "Inventory added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method for removing stocks from Inventory
        public string RemoveInventory(string inventoryId)
        {
            try
            {
               
                var filter = Builders<Inventory>.Filter.Eq(p => p.Id, inventoryId);

                _inventoryCollection.FindOneAndDelete(filter);

                return "Inventory deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Inventory> ListAllInventory()
        {
            try
            {
                var inventory = _inventoryCollection.Find(p => true).ToListAsync().Result;

                foreach (var item in inventory)
                {
                    item.Price = GetTotalInventoryValue().Result;
                }

                return inventory;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<decimal> GetTotalInventoryValue()
        {
            try
            {
                var inventoryList = await _inventoryCollection.Find(p => true).ToListAsync();
                decimal totalValue = 0;

                foreach (var inventory in inventoryList)
                {
                    var product = await _collection.Find(p => p.Id == inventory.Id).FirstOrDefaultAsync();
                    if (product != null)
                    {
                        totalValue += product.Price * inventory.Quantity;
                    }
                }

                return totalValue;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}