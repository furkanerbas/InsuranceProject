using InsureApp.Business.Abstract;
using InsureApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InsureApp.ViewComponents
{
    public class PoliceTuruListViewComponent:ViewComponent
    {
        private IPoliceTuruService _policeTuruService;

        public PoliceTuruListViewComponent(IPoliceTuruService policeTuruService)
        {
            _policeTuruService = policeTuruService; 
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new PoliceTuruListViewModel
            {
                PoliceTuru = _policeTuruService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["policeturu"])
              
            };
            return View(model);
        }

    }
}
