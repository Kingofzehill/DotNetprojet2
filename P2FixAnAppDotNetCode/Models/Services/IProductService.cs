using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        // SMO: TODO T06 ==> UPD for a List<T> of products.
        List<Product> GetAllProducts();
        // SMO: TODO T06 ==> code before update.
        //Product[] GetAllProducts();
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
