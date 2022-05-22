using InsureApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsureApp.Models
{
    public class PoliceListViewModel
    {


        public int CurrentCategory { get; internal set; }

        public string CurrentCategoryText { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public List<PoliceModel> Police { get; internal set; }
        //public Police_Turu PoliceTuru { get; internal set; }
        public List<Police_Turu> PoliceTuru { get; internal set; }
        public List<Odemeler> Odemeler { get; internal set; }
    }
}
