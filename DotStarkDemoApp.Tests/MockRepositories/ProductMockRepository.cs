using DotStarkDemoApp.Repository.DatabaseEntities;
using DotStarkDemoApp.Repository.GenericRepository;
using DotStarkDemoApp.Tests.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotStarkDemoApp.Tests.MockRepositories
{
    public class ProductMockRepository
    {
        private static DotStarkDemoDBEntities dbEntities;
        private static List<Product> products;

        public static GenericRepository<Product> GetRepository()
        {
            dbEntities = new Mock<DotStarkDemoDBEntities>().Object;
            products = DataInitializer.GetProducts();

            // Initialise repository  
            var mockRepo = new Mock<GenericRepository<Product>>(MockBehavior.Default, dbEntities);

            // Setup mocking behavior  
            mockRepo.Setup(p => p.GetAll()).Returns(products);
            mockRepo.Setup(p => p.GetByID(It.IsAny<int>())).Returns(new Func<int, Product>(id => products.Find(p => p.Id.Equals(id))));
            mockRepo.Setup(p => p.GetByID(It.IsAny<string>())).Returns(new Func<string, Product>(id => products.Find(p => p.ProductID.ToLower().Equals(id.ToLower()))));

            mockRepo.Setup(p => p.Insert((It.IsAny<Product>()))).Callback(new Action<Product>(newProduct =>
            {
                dynamic maxProductID = products.OrderByDescending(o => o.Id).FirstOrDefault().Id;
                dynamic nextProductID = maxProductID + 1;
                newProduct.Id = nextProductID;
                newProduct.DateCreated = DateTime.Now;
                products.Add(newProduct);
            }));

            mockRepo.Setup(p => p.Update(It.IsAny<Product>())).Callback(new Action<Product>(x =>
            {
                var user = products.Find(a => a.Id == x.Id);
                user = x;
            }));

            mockRepo.Setup(p => p.Delete(It.IsAny<Product>())).Callback(new Action<Product>(prod =>
            {
                var user = products.Find(a => a.Id == prod.Id);
                if (user != null)
                    products.Remove(user);
            }));

            // Return mock implementation object  
            return mockRepo.Object;
        }

        public static void CleanupRepository()
        {
            if (dbEntities != null)
                dbEntities.Dispose();
        }
    }

}
