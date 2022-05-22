using InsureApp.Business.Abstract;
using InsureApp.Entities.Concrete;
using InsureApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsureApp.Controllers
{
    public class AdminController:Controller
    {
        private IMusteriService _musteriService;


        public AdminController(IMusteriService musteriService)
        {
            _musteriService = musteriService; 


        }

        public ActionResult Index()
        {
            var musteriListViewModel = new MusteriListViewModel
            {
                Musteri = _musteriService.GetAll()
            };
            return View(musteriListViewModel); 
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriService.Add(musteri);
                return RedirectToAction("Index");
                //TempData.Add("Mesaj", "Müşteri ekleme işlemi gerçekleşti.");
            }
            return View();
        }


        public ActionResult Update(int musteriId)

        {
            var model = new MusteriUpdateViewModel
            {
                Musteri = _musteriService.GetById(musteriId),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriService.Update(musteri);
                //TempData.Add("Mesaj", "Müşteri güncelleme işlemi gerçekleşti.");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int musteriId)
        {
            _musteriService.Delete(musteriId);
            //TempData.Add("Mesaj", "Müşteri silme işlemi gerçekleşti.");
            return RedirectToAction("Index");
        }
    }
}
