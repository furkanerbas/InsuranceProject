using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Abstract
{
    public interface IMusteriService
    {
        List<Musteri> GetAll();
        void Add(Musteri musteri);
        void Update(Musteri musteri);
        void Delete(int Mus_id);
        Musteri GetById(int musteriId);
        //void UpdateByPoliceId(int policeNo);
    }
}
