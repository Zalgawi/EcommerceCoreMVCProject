using CoreMVCEcommerce.DataAccess.Data;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;
using CoreMVCEcommerce.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCEcommerce.DataAccess.Repository
{
    public class ColourRepository : Repository<Colour>, IColourRepository
    {
        private readonly ApplicationDbContext _db;

        public ColourRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Colour colour)
        {
            var objFromDb = _db.Colours.FirstOrDefault(s => s.Id == colour.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = colour.Name;
                objFromDb.Code = colour.Code;
                _db.SaveChanges();
            }
        }
    }
}
