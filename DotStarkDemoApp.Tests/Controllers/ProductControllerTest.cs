using DotStarkDemoApp.Host.Controllers.Api;
using DotStarkDemoApp.Models;
using DotStarkDemoApp.Repository.DatabaseEntities;
using DotStarkDemoApp.Repository.GenericRepository;
using DotStarkDemoApp.Repository.UnitOfWork;
using DotStarkDemoApp.Services.Abstract;
using DotStarkDemoApp.Services.Concrete;
using DotStarkDemoApp.Tests.MockRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace DotStarkDemoApp.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        #region Test Setup

        IGenericRepository<Product> productRepository;
        IProductServices productService;
        IUnitOfWork unitOfWork;
        ProductController productController = null;

        [TestInitialize]
        public void Initialize()
        {
            SetupServices();
        }

        private void SetupServices()
        {
            // Unit of Work
            var _unitOfWork = new Mock<IUnitOfWork>();

            // Setup Repositories
            productRepository = ProductMockRepository.GetRepository();

            // Injecting Repositories
            _unitOfWork.SetupGet(s => s.ProductRepository).Returns(productRepository);

            // Finalizing Unit of work
            unitOfWork = _unitOfWork.Object;

            // Creating service and injecting Mock Unit of Work
            productService = new ProductServices(unitOfWork);

            productController = new ProductController(productService);
        }

        [TestCleanup]
        public void Cleanup()
        {
            ProductMockRepository.CleanupRepository();

            unitOfWork = null;
            productRepository = null;
            productService = null;
        }

        #endregion

        [TestMethod]
        public void GetAllProducts_Test()
        {
            // Arrange

            // Act
            IHttpActionResult actionResult = productController.GetAllProducts();

            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<ProductModel>>;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

    }
}
