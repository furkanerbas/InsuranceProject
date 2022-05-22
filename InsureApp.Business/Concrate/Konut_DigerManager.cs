using InsureApp.Business.Abstract;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Concrate
{
    public class Konut_DigerManager:IKonut_DigerService
    {
        private IKonut_DigerDal _konut_digerDal;
        public Konut_DigerManager(IKonut_DigerDal konut_DigerDal)
        {
            _konut_digerDal = konut_DigerDal;
        }
        public void Add(Konut_Diger konut_Diger)
        {
            _konut_digerDal.Add(konut_Diger);
        }

        public void Delete(int konut_id)
        {
            _konut_digerDal.Delete(new Konut_Diger { Konut_id = konut_id });

        }

        public List<Konut_Diger> GetAll()
        {
            return _konut_digerDal.GetList();
        }

        public List<Konut_Diger> GetByCesit(int konut_id)
        {
            return _konut_digerDal.GetList(p => p.Konut_id == konut_id);

            // Veritabanına Entitiy katmanı aracılığıyla where koşullu sorgu gönderiliyor.
            // İstediğim link operasyonlarımı filtrelerimi gerçekleştirdim
        }

        public Konut_Diger GetById(int Konut_id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByPoliceId(int policeNo)
        {
            _konut_digerDal.Delete(x => x.Police_no == policeNo);
        }

        public List<Konut_Diger> GetByPoliceNo(int Police_No)
        {
            throw new NotImplementedException();
        }

        public void Update(Konut_Diger konut_Diger)
        {
            _konut_digerDal.Update(konut_Diger);
        }

    }
}
