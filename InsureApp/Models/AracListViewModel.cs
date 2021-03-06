using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class AracListViewModel
    {
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public List<Arac> Arac { get; internal set; }
        public List<Police> Police { get; internal set; }
    }
}
