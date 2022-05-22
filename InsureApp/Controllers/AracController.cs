using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Business.Abstract;
using InsureApp.Entities.Concrete;
using InsureApp.Models;

namespace InsureApp.Controllers
{
    public class AracController:Controller
    {
        private IAracService _aracService;
        private IPoliceService _policeService;

        public AracController(IPoliceService policeService, IAracService aracService)
        {
            _policeService = policeService;
            _aracService = aracService;
        }

        public ActionResult Index(int page = 1, int policeno = 0)
        {
            //int pageSize = 10;
            var araclar = _aracService.GetAll();
            AracListViewModel model = new AracListViewModel()
            {
                Arac = araclar
              
            };
            return View(model);
            //int pageSize = 10;
            //var arac = _aracService.GetByPoliceNo(policeno);
            //AracListViewModel model = new AracListViewModel()
            //{
            //    Arac = arac.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            //    PageCount = (int)Math.Ceiling(arac.Count / (double)pageSize),
            //    PageSize = pageSize,
            //    CurrentCategory = policeno,
            //    CurrentPage = page
            //};
            //return View(model);
        }
        public ActionResult Add()
        {
            var model = new AracAddListViewModel()
            {
                Arac = new Arac(),
                Police = _policeService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Arac arac)
        {
            if (ModelState.IsValid)
            {
                _aracService.Add(arac);
                // TempData.Add("message","Poliçe başarıyla eklendi");

            }
            return RedirectToAction("Add");

        }
        public ActionResult Update()
        {
            return View();
        }
    }
}
