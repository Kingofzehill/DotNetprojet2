﻿using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
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
        /// Get all product from the inventory
        /// </summary>
        public Product[] GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // thoughout the application
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        /// <params>
        /// <paramref name="id"> Product Id (integer)</paramref>
        /// </params>
        /// <returns>product object (class Product)</returns>
        /// <remarks>TODO T07 DONE (S.MOUREU)</remarks>
        public Product GetProductById(int id)
        {
            // TODO implement the method
            IEnumerable<Product> products = _productRepository.GetAllProducts();
            Product product = products.Where(p => p.Id == id).First();
            return product;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered quantities
        /// </summary>
        /// <param name="cart">Cart (Classe Cart)</param>
        /// <remarks>DONE T08 (SMO)</remarks>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            foreach (CartLine lineCart in cart.cartLines)
            {
                _productRepository.UpdateProductStocks(lineCart.Product.Id, lineCart.Quantity);
            }
        }
    }
}
