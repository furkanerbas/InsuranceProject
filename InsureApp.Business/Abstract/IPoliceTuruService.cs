using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsureApp.Business.Abstract
{
    public interface IPoliceTuruService
    {
        List<Police_Turu> GetAll();
        Police_Turu GetById(int Policetur_id);
        List<Police_Turu> GetByPolice_Turu(int Policetur_id);

    }
}
