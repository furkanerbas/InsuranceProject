using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class AracAddListViewModel
    {
        public Arac Arac { get; set; }
        public List<Police> Police { get; internal set; }
    }
}
