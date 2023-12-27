using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        
        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;            
        }

        /// <summary>
        /// Get all product from the inventory.
        /// </summary>
        /// <returns>List<T> of products.</returns>
        /// <remarks>TODO T06 (SMO) ==> change the return type from array to List.<T>
        /// of products.</remarks>
        public List<Product> GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // thoughout the application.

            List<Product> listOfInventoryProducts = ProductRepository.ProductsRepositoryList
                .Where(p => p.Stock > 0)
                .OrderBy(p => p.Name)
                .ToList();
            return listOfInventoryProducts;
        }
        // SMO: TODO T06, code before update ==> return an array of products.
        /*
        public Product[] GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // thoughout the application

            return _productRepository.GetAllProducts();
        }
        */

        /// <summary>
        /// Get a product form the inventory by its id.
        /// </summary>
        /// <params>
        /// <paramref name="id"> Product Id (integer).</paramref>
        /// </params>
        /// <returns>product object (class Product).</returns>
        /// <remarks>TODO T07 DONE (SMO).</remarks>
        public Product GetProductById(int id)
        {
            // TODO implement the method.
            IEnumerable<Product> products = _productRepository.GetAllProducts();
            return products.Where(p => p.Id == id).First();
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered quantities.
        /// </summary>
        /// <param name="cart">Cart (Class Cart).</param>
        /// <remarks>TODO T08 DONE (SMO).</remarks>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method.
            // update product inventory by using _productRepository.UpdateProductStocks() method.

            // SMO: For each cart line of the cart update the stock inventory of th product.
            foreach (CartLine lineCart in cart.cartLines)
            {
                _productRepository.UpdateProductStocks(
                    lineCart.Product.Id, 
                    lineCart.Quantity);
            }
        }
    }
}
