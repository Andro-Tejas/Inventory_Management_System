using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventortManagement.Models;

namespace InventortManagement.Repository
{
    public interface IMongoRepository
    {
        Task<string> addNewProduct(Product product);

        Task<string> updateExistingProduct(Product product);

        void deleteExistingProduct(string productId);

        Task<List<Product>> listAllProducts();


        // Inventory

        string addNewInventory(Inventory inventory);


        string RemoveInventory(string inventoryId);

        List<Inventory> ListAllInventory();
    }
}