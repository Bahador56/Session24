using Domain.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    public class ClassRoomController : Controller
    {
        #region [ctor]
        private readonly IClassRoomService _classRoomService;
        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        #endregion

        #region [Index]
        [HttpGet]
        public IActionResult Index()
        {
            var list = _classRoomService.GetAll();
            return View(list);
        } 
        #endregion

        #region [create]
        [HttpGet]
        public ViewResult Create()
        {
            var model = _classRoomService.GetNewModelForCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassRoomModel model)
        {
            var result = _classRoomService.Insert(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                 model.SchoolSelectList = _classRoomService.GetNewModelForCreate().SchoolSelectList;
                return View(model);
            }
        }
        #endregion

        #region [edit]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _classRoomService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassRoomModel model)
        {
            var result = _classRoomService.Update(model);
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
            var model = _classRoomService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ClassRoomModel model)
        {
            var result = _classRoomService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);
        } 
        #endregion
    }
}
