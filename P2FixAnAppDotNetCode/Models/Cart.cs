using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class.
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Cart lines list.
        /// </summary>
        /// <remarks>TODO 01 (SMO).</remarks>
        public List<CartLine> cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for dispaly only.
        /// </summary>
        /// <remarks>TODO 01 (SMO).</remarks>
        public IEnumerable<CartLine> Lines => cartLines; //UPD SMO, OLD: Lines => GetCartLineList(); 

        /// <summary>
        /// Return the actual cartline list.
        /// </summary>
        /// <returns>Cart lines List.</returns>
        /// <remarks>TODO 01 (SMO).</remarks>
        private List<CartLine> GetCartLineList()
        {
            // UPD SMO, OLD: ist<CartLine>();. 
            return cartLines; 
        }

        /// <summary>
        /// Memorize ID of the last cart item added
        /// </summary>
        /// <remarks>ADD (SMO)</remarks>
        public static int cartLineId = 0;

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added.
        /// </summary>
        /// <params>
        /// <paramref name="product"> object (class Product) added to the cart.</paramref>/>
        /// <paramref name="quantity"> quantity of the product added to the cart.</paramref>/>
        /// </params>
        /// <remarks>TODO T01 DONE(SMO).</remarks>
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method.
            // SMO: If product does not exist in Cart, add it, otherwise update cart product quantity.
            if (FindProductInCartLines(product.Id) != null)
            {
                CartLine foundCartLine = cartLines.Find(line => line.Product.Id == product.Id); 
                int newQuantity = foundCartLine.Quantity + quantity;
                foundCartLine.Quantity = newQuantity;
            }
            else
            {
                CartLine newLine = new CartLine { OrderLineId = cartLineId++, Product = product, Quantity = quantity };
                cartLines.Add(newLine);
            }
        }

        /// <summary>
        /// Removes a product form the cart.
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart.
        /// </summary>
        /// <returns>Returns a double type variable corresponding 
        /// to the cart total products values.</returns>
        /// <remarks>TODO T02 DONE (SMO)</remarks>
        public double GetTotalValue()
        {
            // TODO implement the method.
            double result = 0.0;
            foreach (CartLine line in GetCartLineList())
            {
                result = result + (line.Quantity * line.Product.Price);
            }

            return result;
        }

        /// <summary>
        /// Get average value of a cart.
        /// </summary>
        /// <returns>Average value (double var type) of products in the cart.</returns>
        /// <remarks>TODO T03 DONE (SMO)?</remarks>
        public double GetAverageValue()
        {
            // TODO implement the method.
            int numberOfProducts = 0;

            // SMO: With the cart list returned by GetCartLineList,
            // calculate the number of products in the cart.
            foreach (CartLine line in GetCartLineList())
            {
                numberOfProducts = numberOfProducts + line.Quantity;
            }
            if (numberOfProducts > 0)
            {
                // SMO: Get the cart total value and divides it by the number of products in the cart.
                double averageValue = (GetTotalValue() / numberOfProducts);
                return averageValue;
            }
            else
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Looks after a given product in the cart 
        /// and returns if it finds it.
        /// </summary>
        /// <param name="productId">Product ID to find.</param>
        /// <remarks>TODO T04 (SMO).</remarks>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method.
            CartLine foundLine = cartLines.Find(line => line.Product.Id == productId);
            if (foundLine != null) 
            { 
                return foundLine.Product; 
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get a specifid cartline by its index.
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products.
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
