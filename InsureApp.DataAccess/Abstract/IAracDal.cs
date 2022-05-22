using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Core.DataAccess;
using InsureApp.Entities.Concrete;

namespace InsureApp.DataAccess.Abstract
{
    public interface IAracDal : IEntityRepository<Arac>
    {
        //Arac Sigortaları ile ilgili özel operasyonlar
        
    }
}