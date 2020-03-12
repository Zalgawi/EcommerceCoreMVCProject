﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCEcommerce.DataAccess.Repository.IRepository;
using CoreMVCEcommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Company Company = new Company();
            if (id == null)
            {
                //this is for create
                return View(Company);
            }
            //this is for edit
            Company = _unitOfWork.Company.Get(id.GetValueOrDefault());
            if (Company == null)
            {
                return NotFound();
            }
            return View(Company);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company Company)
        {
            if (ModelState.IsValid)
            {
                if (Company.Id == 0)
                {
                    _unitOfWork.Company.Add(Company);

                }
                else
                {
                    _unitOfWork.Company.Update(Company);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(Company);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Company.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Company.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}