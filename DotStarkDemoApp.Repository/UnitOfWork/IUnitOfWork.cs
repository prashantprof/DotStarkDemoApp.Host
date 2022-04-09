using DotStarkDemoApp.Repository.DatabaseEntities;
using DotStarkDemoApp.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotStarkDemoApp.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }

        void Save();
    }
}
