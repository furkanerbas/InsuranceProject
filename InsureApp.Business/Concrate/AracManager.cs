using InsureApp.Business.Abstract;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace InsureApp.Business.Concrate
{
    public class AracManager : IAracService
    {
        private IAracDal _aracDal;

        public AracManager(IAracDal aracDal)
        {
            _aracDal = aracDal;
        }

        //public List<Arac> GetByPoliceNo(int police_no)
        //{
        //    return _aracDal.GetList(p => p.Police_no == police_no || police_no == 0);
        //}

        public void Add(Arac arac)
        {
            _aracDal.Add(arac);
        }

        public void DeleteByPoliceId(int policeNo)
        {
            _aracDal.Delete(x => x.Police_no == policeNo);
        }

        public void Delete(int arac_id)
        {
            _aracDal.Delete(new Arac { Arac_id = arac_id });

        }

        public List<Arac> GetAll()
        {
            return _aracDal.GetList();
        }

        public List<Arac> GetById(int arac_id)
        {
            return _aracDal.GetList(p => p.Arac_id == arac_id);
            // Veritabanına Entitiy katmanı aracılığıyla where koşullu sorgu gönderiliyor.
            // İstediğim link operasyonlarımı filtrelerimi gerçekleştirdim
        }

        public void Update(Arac arac)
        {
            _aracDal.Update(arac);
        }

    }
}
