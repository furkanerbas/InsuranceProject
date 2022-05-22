using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class Konut_DigerAddViewModel
    {
        public Konut_Diger Konut_Diger { get; set; }
        public List<Police> Police { get; internal set; }
    }
}
