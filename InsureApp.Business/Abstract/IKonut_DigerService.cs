using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Abstract
{
    public interface IKonut_DigerService
    {
        List<Konut_Diger> GetAll(); //Servis Edilecek işlemler yapılır ...
        List<Konut_Diger> GetByPoliceNo(int Police_No);
        //List<Odemeler> GetByPoliceNo(int Police_no);
        void Add(Konut_Diger konut_diger);
        void Update(Konut_Diger konut_diger);
        void Delete(int Konut_id);
        Konut_Diger GetById(int Konut_id);
        void DeleteByPoliceId(int policeNo);
    }
}
