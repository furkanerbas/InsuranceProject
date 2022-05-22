using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Business.Abstract;
using InsureApp.Entities.Concrete;
using InsureApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace InsureApp.Controllers
{
    public class OdemelerController : Controller
    {

        private IOdemelerService _odemelerService;
        private IMusteriService _musteriservice;
        private IPoliceService _policeService;

        public OdemelerController(IOdemelerService odemelerService,
                                  IPoliceService policeService,
                                  IMusteriService musteriService)
        {
            _odemelerService = odemelerService;
            _policeService = policeService;
            _musteriservice = musteriService;
        }

        public ActionResult Index(int page = 1, int musteri = 0)
        {
            int pageSize = 10;
            var odeme = _odemelerService.GetByMusteriId(musteri);
            OdemelerListViewModel model = new OdemelerListViewModel()
            {
                Odemeler = FixModel(odeme.Skip((page - 1) * pageSize).Take(pageSize).ToList()),
                PageCount = (int)Math.Ceiling(odeme.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = musteri,
                CurrentPage = page
            };
            return View(model);
        }

        private List<OdemelerModel> FixModel(List<Odemeler> toList)
        {
            var result = new List<OdemelerModel>();
            foreach (var item in toList)
            {
                var row = new OdemelerModel();
                var musteri = _musteriservice.GetById(item.Musteri_id);
                var police = _policeService.GetById(item.Police_no);

                row.SigortaBedeli = police.Sigorta_bedeli;
                row.Ad = musteri.Isim;
                row.Soyad = musteri.Soyisim;
                row.FullName = string.Format("{0} {1}", row.Ad, row.Soyad);
                //row.Musteri_id = item.Musteri_id;
                row.Odeme_id = item.Odeme_id;
                row.Odeme_tarihi = item.Odeme_tarihi;
                row.Odenen_tutar = item.Odenen_tutar;
                row.Police_no = police.Police_no;

                result.Add(row);
            }

            return result;
        }

        public ActionResult Add()
        {
            var model = new OdemelerAddViewModel()
            {
                Odemeler = new Odemeler(),
                MusterilerList = FixMusterModel(_musteriservice.GetAll()),
                Police = _policeService.GetAll()
            };
            return View(model);
        }

        private List<MusteriModel> FixMusterModel(List<Musteri> list)
        {
            var result = new List<MusteriModel>();
            foreach (var item in list)
            {
                var row = new MusteriModel();
                //row.FullName = item.Isim + item.Soyisim;
                row.FullName = string.Format("{0}  {1}", item.Isim, item.Soyisim);
                row.Musteri_id = item.Musteri_id;

                result.Add(row);
            }

            return result;
        }

        [HttpPost]
        public ActionResult Add(Odemeler odemeler)
        {
            if (ModelState.IsValid)
            {
                _odemelerService.Add(odemeler);

                // TempData.Add("message","Poliçe başarıyla eklendi");

            }

            return RedirectToAction("Add");

        }

        public ActionResult Update(int odeme_id)

        {
            var model = new OdemelerUpdateViewModel()
            {
                Odemeler = _odemelerService.GetById(odeme_id),
                Musteri = _musteriservice.GetAll(),
                Police =  _policeService.GetAll(),

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Odemeler odemeler)
        {
            if (ModelState.IsValid)
            {
                _odemelerService.Update(odemeler);
                //TempData.Add("Mesaj", "Müşteri güncelleme işlemi gerçekleşti.");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int odeme_id)
        {
            _odemelerService.Delete(odeme_id);
            //TempData.Add("Mesaj", "Müşteri silme işlemi gerçekleşti.");
            return RedirectToAction("Index");
        }
    }
}
