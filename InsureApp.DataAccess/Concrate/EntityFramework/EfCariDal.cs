using System;
using System.Collections.Generic;
using System.Text;
using InsureApp.Core.DataAccess.EntityFramework;
using InsureApp.DataAccess.Abstract;
using InsureApp.Entities.Concrete;

namespace InsureApp.DataAccess.Concrate.EntityFramework
{
    public class EfCariDal : EfEntityRepositoryBase<Cari, DatabaseContext>, ICariDal
    {
    }
}
