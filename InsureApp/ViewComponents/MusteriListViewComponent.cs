using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Business.Abstract;
using InsureApp.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace InsureApp.ViewComponents
{
    public class MusteriListViewComponent : ViewComponent
    {
        private IMusteriService _musteriService;

        public MusteriListViewComponent(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new MusteriListViewModel
            {
                Musteri = _musteriService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["musteri"])

            };
            return View(model);
        }

    }
}
