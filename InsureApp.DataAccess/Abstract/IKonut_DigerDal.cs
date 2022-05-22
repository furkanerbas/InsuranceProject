using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Core.DataAccess;
using InsureApp.Entities.Concrete;

namespace InsureApp.DataAccess.Abstract
{
    public interface IKonut_DigerDal : IEntityRepository<Konut_Diger>
    {
        //Konut ve Diger Sigortalar ile ilgili özel operasyonlar
        
    }
}