using CoreMVCEcommerce.DataAccess.Data;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;
using CoreMVCEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreMVCEcommerce.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }

                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price100 = product.Price100;
                objFromDb.Name = product.Name;
                objFromDb.Description = product.Description;
                objFromDb.SizeId = product.SizeId;
                objFromDb.ColourId = product.ColourId;


            }
        }
    }
}
