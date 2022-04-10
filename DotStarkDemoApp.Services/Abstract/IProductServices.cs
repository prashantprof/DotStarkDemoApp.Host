using DotStarkDemoApp.Models;
using System.Collections.Generic;

namespace DotStarkDemoApp.Services.Abstract
{
    /// <summary>  
    /// Product Service Contract  
    /// </summary>  
    public interface IProductServices
    {
        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ProductModel GetProductById(int productId);

        /// <summary>
        /// Get a product by product SKU ID.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ProductModel GetProductByProductId(string productId);

        /// <summary>
        /// Check the product availability.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quntityRequired"></param>
        /// <returns></returns>
        ProductModel CheckProductAvailability(string productId, int quntityRequired);

        /// <summary>
        /// Get all product list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductModel> GetAllProducts();

        /// <summary>
        /// Add a new product record.
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        int AddProduct(NewProductModel productEntity);

        /// <summary>
        /// Update a product details.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        bool UpdateProduct(int productId, ProductModel productEntity);

        /// <summary>
        /// Delete an existing product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        bool DeleteProduct(int productId);
    }
}
