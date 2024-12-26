using InventortManagement.Models;
using InventortManagement.Repository;
using InventortManagement.Validator;

namespace InventortManagement.Services
{
    public class ProductService
    {
        private IMongoRepository _mongoRepository;

        private ProductValidator productValidator;

        public ProductService(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
            productValidator = new ProductValidator();
        }

        // Method for creating new Product
        public string AddNewProduct(Product product)
        {
            try
            {

                var errors = productValidator.Validate(product);

                if (!errors.IsValid)
                {
                    return errors.ToString();
                }

                return _mongoRepository.addNewProduct(product).Result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method for updating the product
        public string UpdateProduct(Product product)
        {
            try
            {

                var errors = productValidator.Validate(product);

                if (!errors.IsValid)
                {
                    return errors.ToString();
                }

                return _mongoRepository.updateExistingProduct(product).Result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Method for deleting the product
        public void DeleteProduct(string productId)
        {
            try
            {
                _mongoRepository.deleteExistingProduct(productId);

            }
            catch (Exception ex)
            {
                
            }
        }

        // Method to get All Products - List
        public List<Product> GetAllProducts()
        {
            try
            {
                return _mongoRepository.listAllProducts().Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}