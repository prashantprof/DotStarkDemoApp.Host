using DotStarkDemoApp.Repository.DatabaseEntities;
using DotStarkDemoApp.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotStarkDemoApp.Repository.UnitOfWork
{
    /// <summary>  
    /// Unit of Work class responsible for DB transactions  
    /// </summary>  
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotStarkDemoDBEntities context = null;
        public UnitOfWork()
        {
            context = new DotStarkDemoDBEntities();
        }

        private IGenericRepository<Product> productRepository;
        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new GenericRepository<Product>(context);
                return productRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        #region Implementing IDiosposable...  

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
