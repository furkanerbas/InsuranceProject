using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class PoliceTuruListViewModel
    {
        public List<Police_Turu> PoliceTuru { get; internal set; }
        public int CurrentCategory { get; internal set; }
        
    }
}
