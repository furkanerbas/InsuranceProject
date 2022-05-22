using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Business.Abstract;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;

namespace InsureApp.Business.Concrate
{
    public class PoliceTuruManager : IPoliceTuruService
    {
        private IPolice_TuruDal _policeTuruDal;

        public PoliceTuruManager(IPolice_TuruDal policeTuruDal)
        {
            _policeTuruDal = policeTuruDal;
        }

        public List<Police_Turu> GetAll()
        {
           return _policeTuruDal.GetList();
        }

        public List<Police_Turu> GetByPolice_Turu(int Policetur_id)
        {
            return _policeTuruDal.GetList(x=>x.Policetur_id==Policetur_id);
        }

        public Police_Turu GetById(int Policetur_id)
        {
            return _policeTuruDal.Get(p => p.Policetur_id == Policetur_id);

            // Veritabanına Entitiy katmanı aracılığıyla where koşullu sorgu gönderiliyor.
            // İstediğim link operasyonlarımı filtrelerimi gerçekleştirdim
        }
    }
}
