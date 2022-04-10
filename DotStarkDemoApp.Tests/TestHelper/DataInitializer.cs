using DotStarkDemoApp.Repository.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotStarkDemoApp.Tests.TestHelper
{
    public static class DataInitializer
    {
        private static DotStarkDemoDBEntities dbEntities;
        private static List<Product> products = null;

        static DataInitializer()
        {
            dbEntities = new DotStarkDemoDBEntities();
        }

        public static List<Product> GetProducts()
        {
            products = dbEntities.Products.Take(5).ToList();
            return products;
        }

    }
}
