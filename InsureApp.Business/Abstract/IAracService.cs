using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Abstract
{
    public interface IAracService
    {
        List<Arac> GetAll(); //Servis Edilecek işlemler yapılır ...
        //List<Arac> GetByPoliceNo(int Police_No);
        //List<Odemeler> GetByPoliceNo(int Police_no);
        void Add(Arac arac);
        void Update(Arac arac);
        void DeleteByPoliceId(int policeNo);
        void Delete(int Arac_id);
    }
}
