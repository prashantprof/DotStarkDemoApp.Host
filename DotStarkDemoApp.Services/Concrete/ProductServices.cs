using AutoMapper;
using DotStarkDemoApp.Models;
using DotStarkDemoApp.Repository.DatabaseEntities;
using DotStarkDemoApp.Repository.UnitOfWork;
using DotStarkDemoApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace DotStarkDemoApp.Services.Concrete
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductServices()
        {
            unitOfWork = new UnitOfWork();
        }

        public ProductServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int AddProduct(NewProductModel productEntity)
        {
            using (var scope = new TransactionScope())
            {
                var product = new Product
                {
                    Id = 0,
                    ProductID = productEntity.ProductID,
                    ProductName = productEntity.ProductName,
                    Quantity = productEntity.Quantity,
                    DateCreated = DateTime.Now
                };
                unitOfWork.ProductRepository.Insert(product);
                unitOfWork.Save();
                scope.Complete();
                return product.Id;
            }
        }

        public ProductModel CheckProductAvailability(string productId, int quntityRequired)
        {
            var product = unitOfWork.ProductRepository.GetWithInclude(
                predicate: x => x.ProductID.ToLower().Equals(productId.ToLower()) && x.Quantity >= quntityRequired
            ).FirstOrDefault();

            if (product != null)
            {
                Mapper.CreateMap<Product, ProductModel>();
                var productModel = Mapper.Map<Product, ProductModel>(product);
                return productModel;
            }
            else
            {
                throw new Exception(string.Format("Product is not available for the required quanity: {0}.", quntityRequired));
            }
        }

        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = unitOfWork.ProductRepository.GetByID(productId);
                    if (product != null)
                    {
                        unitOfWork.ProductRepository.Delete(product);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var products = unitOfWork.ProductRepository.GetAll().ToList();
            if (products.Any())
            {
                Mapper.CreateMap<Product, ProductModel>();
                var productsModel = Mapper.Map<List<Product>, List<ProductModel>>(products);
                return productsModel;
            }
            return null;
        }

        public ProductModel GetProductById(int productId)
        {
            var product = unitOfWork.ProductRepository.GetByID(productId);
            if (product != null)
            {
                Mapper.CreateMap<Product, ProductModel>();
                var productModel = Mapper.Map<Product, ProductModel>(product);
                return productModel;
            }
            return null;
        }

        public ProductModel GetProductByProductId(string productId)
        {
            var product = unitOfWork.ProductRepository.GetWithInclude(
               predicate: x => x.ProductID.ToLower().Equals(productId.ToLower())
            ).FirstOrDefault();

            if (product != null)
            {
                Mapper.CreateMap<Product, ProductModel>();
                var productModel = Mapper.Map<Product, ProductModel>(product);
                return productModel;
            }
            else
            {
                throw new Exception("Product is not available.");
            }
        }

        public bool UpdateProduct(int productId, ProductModel productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var product = unitOfWork.ProductRepository.GetByID(productId);
                    if (product != null)
                    {
                        product.ProductName = productEntity.ProductName;
                        product.Quantity = productEntity.Quantity;
                        product.DateUpdate = DateTime.Now;

                        unitOfWork.ProductRepository.Update(product);
                        unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
