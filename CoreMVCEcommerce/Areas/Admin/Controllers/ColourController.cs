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
    public class ColourController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColourController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Colour Colour = new Colour();
            if (id == null)
            {
                //this is for create
                return View(Colour);
            }
            //this is for edit
            Colour = _unitOfWork.Colour.Get(id.GetValueOrDefault());
            if (Colour == null)
            {
                return NotFound();
            }
            return View(Colour);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Colour Colour)
        {
            if (ModelState.IsValid)
            {
                if (Colour.Id == 0)
                {
                    _unitOfWork.Colour.Add(Colour);

                }
                else
                {
                    _unitOfWork.Colour.Update(Colour);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(Colour);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Colour.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Colour.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Colour.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}