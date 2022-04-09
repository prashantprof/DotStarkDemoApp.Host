using DotStarkDemoApp.Services.Abstract;
using DotStarkDemoApp.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotStarkDemoApp.Host.Controllers.Api
{
    public class ProductController : ApiController
    {
        private readonly IProductServices _productServices;

        #region Public Constructor  

        /// <summary>  
        /// Public constructor to initialize product service instance  
        /// </summary>  
        public ProductController()
        {
            _productServices = new ProductServices();
        }

        #endregion


    }
}
