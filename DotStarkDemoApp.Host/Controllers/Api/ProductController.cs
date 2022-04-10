using DotStarkDemoApp.Models;
using DotStarkDemoApp.Services.Abstract;
using DotStarkDemoApp.Services.Concrete;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace DotStarkDemoApp.Host.Controllers.Api
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductServices productService = null;

        public ProductController() : this(new ProductServices()) { }

        public ProductController(IProductServices productService)
        {
            this.productService = productService;
        }

        #region Public Constructor  

        /// <summary>
        /// Get the list of all the available Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-products")]
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetAllProducts()
        {
            return Ok(productService.GetAllProducts());
        }

        /// <summary>
        /// Get product by product id
        /// </summary>
        /// <param name="productId">Id of the product.</param>
        [HttpGet]
        [Route("get-product-by-id")]
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetProductById(string productId)
        {
            return Ok(productService.GetProductByProductId(productId));
        }

        /// <summary>
        /// Check product availability by product id and quanity required.
        /// </summary>
        /// <param name="productId">Id of the product.</param>
        [HttpPost]
        [Route("check-product-availability")]
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult CheckProductAvailability(string productId, int quntityRequired)
        {
            return Ok(productService.CheckProductAvailability(productId, quntityRequired));
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-new-product")]
        [ResponseType(typeof(ServiceResponseModel))]
        public IHttpActionResult AddNewProduct(NewProductModel product)
        {
            int newProductId = productService.AddProduct(product);
            if (newProductId > 0)
            {
                return Ok(new ServiceResponseModel()
                {
                    IsSuccessStatusCode = true,
                    Message = "New Product has been added successfully.",
                    StatusCode = HttpStatusCode.OK,
                    Data = newProductId
                });
            }
            else
            {
                return Ok(new ServiceResponseModel()
                {
                    IsSuccessStatusCode = false,
                    Message = "New Product cannot be added this time, Please try again!",
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = "Server error"
                });
            }
        }


        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-product-stock")]
        [ResponseType(typeof(ServiceResponseModel))]
        public IHttpActionResult UpdateProductStock(int productId, int quantity)
        {
            var existingProduct = productService.GetProductById(productId);

            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;

                if (productService.UpdateProduct(productId, existingProduct))
                {
                    return Ok(new ServiceResponseModel()
                    {
                        IsSuccessStatusCode = true,
                        Message = "Product stock has been updated successfully.",
                        StatusCode = HttpStatusCode.OK,
                        Data = existingProduct
                    });
                }
            }

            return Ok(new ServiceResponseModel()
            {
                IsSuccessStatusCode = false,
                Message = string.Format("Product is not available with the Id: {0}", productId),
                StatusCode = HttpStatusCode.BadRequest,
                ReasonPhrase = "Bad Request"
            });

        }


        #endregion

    }
}
