using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCEcommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISizeRepository Size { get; }
        IColourRepository Colour { get; }
        IProductRepository Product { get; }
       
        //ISP_Call SP_Call { get; }

        void Save();


    }
}
