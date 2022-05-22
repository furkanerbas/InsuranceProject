using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Core.DataAccess.EntityFramework;
using InsureApp.Entities.Concrete;
using InsureApp.DataAccess.Abstract;

namespace InsureApp.DataAccess.Concrate.EntityFramework
{
    public class EfMusteriDal : EfEntityRepositoryBase<Musteri,DatabaseContext>,IMusteriDal
    {
        
    }
}
