using CoreMVCEcommerce.DataAccess.Data;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;
using CoreMVCEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreMVCEcommerce.DataAccess.Repository
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        private readonly ApplicationDbContext _db;

        public SizeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Size size)
        {
            var objFromDb = _db.Sizes.FirstOrDefault(s => s.Id == size.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = size.Name;
                objFromDb.Code = size.Code;

            }
        }
    }
}
