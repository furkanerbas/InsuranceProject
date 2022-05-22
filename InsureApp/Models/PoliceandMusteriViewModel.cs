using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class PoliceandMusteriViewModel
    {
        public Police Police { get; set; }
        public Musteri Musteri { get; set; }
        public Odemeler Odemeler { get; set; }
    }
}
