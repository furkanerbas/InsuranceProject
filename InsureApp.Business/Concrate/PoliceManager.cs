using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Business.Abstract;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;

namespace InsureApp.Business.Concrate
{
   public class PoliceManager : IPoliceService
   {
       private IPoliceDal _policeDal;

       public PoliceManager(IPoliceDal policeDal)
       {
           _policeDal = policeDal;

       }
        public List<Police> GetAll()
        {
            return _policeDal.GetList();
        }

        public List<Police> GetByPolice_Turu(int Policetur_id)
        {
            return _policeDal.GetList(p => p.Policetur_id == Policetur_id || Policetur_id == 0);
        }

        public void Add(Police police)
        {
            _policeDal.Add(police);
        }

        public void Update(Police police)
        {
            _policeDal.Update(police);
        }

        public void Delete(int police_no)
        {
            _policeDal.Delete(new Police {Police_no = police_no});
        }

        public Police GetById(int police_no)
        {
            return _policeDal.Get(p => p.Police_no == police_no);
        }
    }
}
