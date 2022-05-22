using InsureApp.Business.Abstract;
using InsureApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsureApp.Controllers
{
    public class MusteriController:Controller
    {
        private IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
           _musteriService = musteriService;
        }

        public ActionResult Index(int page=1)
        {
            //int pageSize = 10;
            var musteriler = _musteriService.GetAll();
            MusteriListViewModel model = new MusteriListViewModel
            {
                Musteri = musteriler
                //Musteriler = musteriler.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                //PageCount = (int)Math.Ceiling(musteriler.Count / (double)pageSize),
                //PageSize = pageSize,
                //CurrentMusteri = musteriler,
                //CurrentPage = page
            };
            return View(model);
        }
    }
}
