 using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Core.DataAccess;
using InsureApp.Entities.Concrete;

namespace InsureApp.DataAccess.Abstract
{
    public interface IMusteriDal : IEntityRepository<Musteri>
    {
        //Musteri ile ilgili özel operasyonlar
      
    }
}