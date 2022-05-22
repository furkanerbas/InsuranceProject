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
    public class Konut_DigerController : Controller
    {
        private IKonut_DigerService _konutDigerService;
        private IPoliceService _policeService;

        public Konut_DigerController(IKonut_DigerService konutDigerService, IPoliceService policeService)
        {
            _konutDigerService = konutDigerService;
            _policeService = policeService;
        }
        
        public ActionResult Index(int page = 1, int policeno = 0)
        {
            //int pageSize = 10;
            var konutlar = _konutDigerService.GetAll();
            Konut_DigerListViewModel model = new Konut_DigerListViewModel()
            {
                Konut_Diger = konutlar

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
            var model = new Konut_DigerAddViewModel()
            {
                Konut_Diger = new Konut_Diger(),
                Police = _policeService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Konut_Diger konutDiger)
        {
            if (ModelState.IsValid)
            {
                _konutDigerService.Add(konutDiger);
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

