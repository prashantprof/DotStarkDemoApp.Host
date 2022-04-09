using DotStarkDemoApp.Models;
using System.Collections.Generic;

namespace DotStarkDemoApp.Services.Abstract
{
    /// <summary>  
    /// Product Service Contract  
    /// </summary>  
    public interface IProductServices
    {
        ProductModel GetProductById(int productId);

        ProductModel GetProductByProductId(string productId);

        ProductModel CheckProductAvailability(string productId, int quntityRequired);

        IEnumerable<ProductModel> GetAllProducts();

        int AddProduct(ProductModel productEntity);

        bool UpdateProduct(int productId, ProductModel productEntity);

        bool DeleteProduct(int productId);
    }
}
