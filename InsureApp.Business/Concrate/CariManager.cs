using InsureApp.Business.Abstract;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace InsureApp.Business.Concrate
{
    public class CariManager : ICariService
    {
        private IOdemelerDal _odemelerDal;

        public CariManager(IOdemelerDal odemelerDal)
        {
            _odemelerDal = odemelerDal;

        }
        public List<Odemeler> GetAll()
        {
            return _odemelerDal.GetList();
        }

        public List<Odemeler> GetByPoliceNo(int police_no)
        {
            return _odemelerDal.GetList(p => p.Police_no == police_no || police_no == 0);
        }

        public List<Odemeler> GetByMusteriId(int musteri_id)
        {
            return _odemelerDal.GetList(p => p.Musteri_id == musteri_id || musteri_id == 0);
        }

        public void Add(Odemeler odemeler)
        {
            _odemelerDal.Add(odemeler);
        }

        public void Update(Odemeler odemeler)
        {
            _odemelerDal.Update(odemeler);
        }

        public void Delete(int odeme_no)
        {
            _odemelerDal.Delete(new Odemeler { Odeme_id = odeme_no });
        }

        public void DeleteByPoliceId(int policeNo)
        {
            _odemelerDal.Delete(x => x.Police_no == policeNo);
        }

        //public void UpdateByPoliceId(int policeNo)
        //{
        //    _odemelerDal.Update(x => x.Police_no == policeNo);
        //}

        public Odemeler GetById(int police_no)
        {
            return _odemelerDal.Get(p => p.Police_no == police_no);
        }
    }
}
