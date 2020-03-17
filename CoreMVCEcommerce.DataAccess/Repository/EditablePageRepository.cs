using CoreMVCEcommerce.DataAccess.Data;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;
using CoreMVCEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCEcommerce.DataAccess.Repository
{
    public class EditablePageRepository : Repository<EditablePage>, IEditablePageRepository
    {
        private readonly ApplicationDbContext _db;

        public EditablePageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EditablePage editablePage)
        {
            _db.Update(editablePage);
        }
    }
}
