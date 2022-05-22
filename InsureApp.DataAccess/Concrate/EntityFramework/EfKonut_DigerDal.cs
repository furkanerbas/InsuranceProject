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
    public class EfKonut_DigerDal : EfEntityRepositoryBase<Konut_Diger, DatabaseContext>, IKonut_DigerDal
    {

    }
}
