using Domain.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    public class SchoolController : Controller
    {
        #region [ctor]
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        #endregion

        #region [Index]
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var list = _schoolService.GetAll();
            return View(list);
        } 
        #endregion

        #region [create]
        [HttpGet]
        [Authorize(Roles ="admin")]
        public ViewResult Create()
        {
            return View(new SchoolModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(SchoolModel model)
        {
            var result = _schoolService.Insert(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(model);
            }
        }
        #endregion

        #region [edit]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _schoolService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolModel model)
        {
            var result = _schoolService.Update(model);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);
        }
        #endregion

        #region [Delete]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _schoolService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(SchoolModel model)
        {
            var result = _schoolService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);
        } 
        #endregion
    }
}
