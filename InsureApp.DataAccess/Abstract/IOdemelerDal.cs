 using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Core.DataAccess;
using InsureApp.Entities.Concrete;

namespace InsureApp.DataAccess.Abstract
{
    public interface IOdemelerDal : IEntityRepository<Odemeler>
    {
        //Musteri ile ilgili özel operasyonlar
        
    }
}