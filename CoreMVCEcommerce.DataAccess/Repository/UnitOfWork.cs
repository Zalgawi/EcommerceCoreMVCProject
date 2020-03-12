using System;
using System.Collections.Generic;
using System.Text;
using CoreMVCEcommerce.DataAccess.Data;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;

namespace CoreMVCEcommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Size = new SizeRepository(_db);
            Colour = new ColourRepository(_db);
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
            //Company = new CompanyRepository(_db);
            //ApplicationUser = new ApplicationUserRepository(_db);


        }

        public ISizeRepository Size { get; private set; }
        public IColourRepository Colour { get; private set; }
        public IProductRepository Product { get; private set; }
        public ISP_Call SP_Call { get; private set; }
        //public ICompanyRepository Company { get; private set; }
        //public IApplicationUserRepository ApplicationUser { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
