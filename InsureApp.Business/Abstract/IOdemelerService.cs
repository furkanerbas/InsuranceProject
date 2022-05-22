using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Abstract
{
    public interface IOdemelerService
    {
        List<Odemeler> GetAll();
        List<Odemeler> GetByMusteriId(int Musteri_id);
        List<Odemeler> GetByPoliceNo(int Police_no);
        void Add(Odemeler odemeler);
        void Update(Odemeler odemeler);
        void Delete(int Odeme_id);
        void DeleteByPoliceId(int policeNo);
        Odemeler GetById(int police_no);
    }
}
