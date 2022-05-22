using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Abstract
{
    public interface IPoliceService
    {
        List<Police> GetAll();
        List<Police> GetByPolice_Turu(int Policetur_id);
        void Add(Police police);
        void Update(Police police);
        void Delete(int Police_no);
        Police GetById(int Police_no);
    }


}
