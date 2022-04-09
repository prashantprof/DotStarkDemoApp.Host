using DotStarkDemoApp.Models;
using DotStarkDemoApp.Services.Abstract;
using DotStarkDemoApp.Services.Concrete;
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



        #endregion

    }
}
