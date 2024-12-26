

using InventortManagement.Models;
using InventortManagement.Repository;
using InventortManagement.Services;

Product product = new Product();

MongoRepository mongoRepository = new MongoRepository();

ProductService productService = new ProductService(mongoRepository);

InventoryService inventoryService = new InventoryService(mongoRepository);


// Product Management System

Console.WriteLine("1. Add new product");
Console.WriteLine("2. Update product");
Console.WriteLine("3. Delete product");
Console.WriteLine("4. List all products");

// Inventory Management System

Console.WriteLine("5. Add new inventory");
Console.WriteLine("6. Remove inventory");
Console.WriteLine("7. List Inventory");
Console.WriteLine("8. Exit");

Console.WriteLine("Choose an option: ");

int choice = Convert.ToInt32(Console.ReadLine());

while (choice != 8)
{
    switch (choice)
    {
        case 1:
            // add new product
            Console.WriteLine("Enter product name: ");
            String? name = Console.ReadLine();

            Console.WriteLine("Enter Product Description");
            String? description = Console.ReadLine();

            Console.WriteLine("Enter Product Price");
            decimal price = Convert.ToDecimal(Console.ReadLine());


            product.Name = name;
            product.Description = description;
            product.Price = price;

            string result = productService.AddNewProduct(product);

            Console.WriteLine(result);

            break;

        case 2:
            // update product
            Console.WriteLine("Enter product name: ");
            String? updatedProductName = Console.ReadLine();

            Console.WriteLine("Enter Product Description");
            String? updatedProductDescription = Console.ReadLine();

            Console.WriteLine("Enter Product Price");
            decimal updatedProductPrice = Convert.ToDecimal(Console.ReadLine());

            Product updatedProduct = new Product()
            {
                Name = updatedProductName,
                Description = updatedProductDescription,
                Price = updatedProductPrice
            };

            string updatedResult = productService.UpdateProduct(updatedProduct);

            Console.WriteLine(updatedResult);
            break;

        case 3:
            // update product
            Console.WriteLine("Enter product id: ");
            String? id = Console.ReadLine();

            productService.DeleteProduct(id);

            Console.WriteLine("Product Deleted Successfully");
            break;

        case 4:
            Console.WriteLine("List of all products");

            List<Product> products = productService.GetAllProducts();

            if (products.Count == 0)
            {
                System.Console.WriteLine("No Products Found");
                break;
            }

            foreach (Product p in products)
            {
                Console.Write(p.Name + " - ");
                Console.Write(p.Description + " - ");
                Console.Write(p.Price + " - ");

                Console.WriteLine("\n");
            }

            break;

        case 5:
            // Inventory
            // add new product
            Console.WriteLine("Enter product Id: ");
            String? productId = Console.ReadLine();

            Console.WriteLine("Enter Product Quantity");
            int Quantity = Convert.ToInt32(Console.ReadLine());

            Inventory inventory = new Inventory()
            {
                Id = productId,
                Quantity = Quantity
            };

            string inventoryResult = inventoryService.AddNewInventory(inventory);

            System.Console.WriteLine(inventoryResult);

            break;

        case 6:

            // add new product
            Console.WriteLine("Enter Inventory Product Id: ");
            String? inventoryId = Console.ReadLine();

            inventoryService.RemoveInventory(inventoryId);

            break;

        case 7:
            System.Console.WriteLine("Listing Inventory For Basic Reporting");
            List<Inventory> inventoryProducts = inventoryService.ListAllInventory();

            if (inventoryProducts.Count == 0)
            {
                System.Console.WriteLine("No Inventory Products Found");
                break;
            }

            foreach (Inventory inventoryProduct in inventoryProducts)
            {
                Console.Write(inventoryProduct.Id + " - ");
                Console.Write(inventoryProduct.Quantity + " - ");
                Console.Write(inventoryProduct.Price + " - ");

                Console.WriteLine("\n");
            }

            break;

        case 8:
            System.Console.WriteLine("Exiting Program");
            return;

        default:
            System.Console.WriteLine("Invalid Choice");
            break;
    }
    Console.WriteLine("Choose an option: ");
    choice = Convert.ToInt32(Console.ReadLine());



}