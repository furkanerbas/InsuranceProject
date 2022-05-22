using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class OdemelerListViewModel
    {
        public int CurrentCategory { get; internal set; }
       // public string CurrentCategoryText { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public List<OdemelerModel> Odemeler { get; internal set; }
        public List<MusteriModel> MusterilerList { get; internal set; }
        public List<PoliceModel> Police { get; internal set; }
    }
}
