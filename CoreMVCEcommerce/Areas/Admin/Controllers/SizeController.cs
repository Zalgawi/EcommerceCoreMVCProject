using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;
using CoreMVCEcommerce.Models;
using CoreMVCEcommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class SizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Size Size = new Size();
            if (id == null)
            {
                //this is for create
                return View(Size);
            }
            //this is for edit
            Size = _unitOfWork.Size.Get(id.GetValueOrDefault());
            if (Size == null)
            {
                return NotFound();
            }
            return View(Size);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Size Size)
        {
            if (ModelState.IsValid)
            {
                if (Size.Id == 0)
                {
                    _unitOfWork.Size.Add(Size);

                }
                else
                {
                    _unitOfWork.Size.Update(Size);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(Size);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Size.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Size.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Size.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}