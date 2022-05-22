using InsureApp.Business.Abstract;
using InsureApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsureApp.Controllers
{
    public class PoliceController:Controller
    {
        private IPoliceService _policeService;
        private IPoliceTuruService _policeturuservice;
        private IMusteriService _musteriservice;
        private IAracService _aracService;
        private IKonut_DigerService _konutDigerService;
        private IOdemelerService _odemelerService;

        public PoliceController(IPoliceService policeService, 
                                IPoliceTuruService policeturuService, 
                                IMusteriService musteriService,
                                IAracService aracService,
                                IKonut_DigerService konutDigerService,
                                IOdemelerService odemelerService)
        {
            _policeService = policeService;
            _policeturuservice = policeturuService;
            _musteriservice = musteriService;
            _aracService = aracService;
            _konutDigerService = konutDigerService;
            _odemelerService = odemelerService;
        }

        public ActionResult Index(int page = 1, int policeturu = 0)
        {
            int pageSize = 10;
            var police = _policeService.GetByPolice_Turu(policeturu);
            var policTuru = _policeturuservice.GetByPolice_Turu(policeturu).FirstOrDefault();
            PoliceListViewModel model = new PoliceListViewModel
            {
                Police = FixModel(police.Skip((page -1) * pageSize).Take(pageSize).ToList()),
                PageCount = (int)Math.Ceiling(police.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = policTuru != null ? policTuru.Policetur_id : 0,
                CurrentCategoryText = policTuru != null ? policTuru.Police_turu : string.Empty,
                CurrentPage = page
            };
            return View(model);
        }

        private List<PoliceModel> FixModel(List<Police> toList)
        {
            var result = new List<PoliceModel>();
            foreach (var item in toList)
            {
                var row = new PoliceModel();
                var musteri = _musteriservice.GetById(item.Musteri_id);
                var policeturu = _policeturuservice.GetById(item.Policetur_id);

                row.PoliceTuru = policeturu.Police_turu;
                row.Ad = musteri.Isim;
                row.Soyad = musteri.Soyisim;
                row.Policetur_id = policeturu.Policetur_id;
                row.Baslangic_tarihi = item.Baslangic_tarihi;
                row.Bitis_tarihi = item.Bitis_tarihi;
                row.Vize_tarihi = item.Vize_tarihi;
                row.Sigorta_bedeli = item.Sigorta_bedeli;
                row.Police_no = item.Police_no;
                row.FullName = string.Format("{0} {1}",row.Ad,row.Soyad);
                result.Add(row);
            }

            return result;
        }


        public ActionResult Add()
        {
            var model = new PoliceAddViewListModel
            {
                Police = new Police(),
                PoliceTuru = _policeturuservice.GetAll(),
                MusterilerList = FixMusterModel( _musteriservice.GetAll())
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
        public ActionResult Add(Police police)
        {
            if (ModelState.IsValid)
            {

                
                _policeService.Add(police);
                // TempData.Add("message","Poliçe başarıyla eklendi");
                
            }
            return RedirectToAction("Add");

        }

        public ActionResult Update(int police_No)
             
        {
            var model = new PoliceUpdateViewModel()
            {
                Police = _policeService.GetById(police_No),
                Musteri = _musteriservice.GetAll(),
                PoliceTuru = _policeturuservice.GetAll()
               
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Police police)
        {
            if (ModelState.IsValid)
            {
                _policeService.Update(police);
                //TempData.Add("Mesaj", "Müşteri güncelleme işlemi gerçekleşti.");
            }
            return RedirectToAction("Update");
        }

        public ActionResult Delete(int Police_no)
        {
            _aracService.DeleteByPoliceId(Police_no);
            _konutDigerService.DeleteByPoliceId(Police_no);
            _odemelerService.DeleteByPoliceId(Police_no);
            _policeService.Delete(Police_no);
            //TempData.Add("Mesaj", "Müşteri silme işlemi gerçekleşti.");
            return RedirectToAction("Index");
        }
    }
}
