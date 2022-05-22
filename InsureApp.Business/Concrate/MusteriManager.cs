using InsureApp.Business.Abstract;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Concrate
{
    public class MusteriManager:IMusteriService
    {
        private IMusteriDal _musteriDal;

        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;        
        }

        public void Add(Musteri musteri)
        {
            _musteriDal.Add(musteri);
        }

        public void Delete(int musteri_id)
        {
            _musteriDal.Delete(new Musteri { Musteri_id = musteri_id });
        }

        public List<Musteri> GetAll()
        {
            return _musteriDal.GetList();
        }

        public Musteri GetById (int musteri_Id)
        {
            return _musteriDal.Get(p => p.Musteri_id == musteri_Id);

            // Veritabanına Entitiy katmanı aracılığıyla where koşullu sorgu gönderiliyor.
            // İstediğim link operasyonlarımı filtrelerimi gerçekleştirdim
        }

        //public void UpdateByPoliceId(int policeNo)
        //{
        //    return _musteriDal.Get(p => p.Musteri_id == policeNo);
        //}

        public void Update(Musteri musteri)
        {
            _musteriDal.Update(musteri);
        }
        
    }
}
