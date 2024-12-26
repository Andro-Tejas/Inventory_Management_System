using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventortManagement.Models;
using InventortManagement.Repository;
using InventortManagement.Validator;

namespace InventortManagement.Services
{
    public class InventoryService
    {
        private IMongoRepository _mongoRepository;


        public InventoryService(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        // Method for creating new Inventory for Product
        public string AddNewInventory(Inventory inventory)
        {
            try
            {
                return _mongoRepository.addNewInventory(inventory);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method to remove Inventory from Product
        public string RemoveInventory(string inventoryId)
        {
            try
            {
                return _mongoRepository.RemoveInventory(inventoryId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method to list all Inventory
        public List<Inventory> ListAllInventory(){
            try{

                return _mongoRepository.ListAllInventory();

            }catch(Exception ex){
                return null;
            }
        }
    }
}