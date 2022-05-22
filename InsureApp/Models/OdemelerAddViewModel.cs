using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class OdemelerAddViewModel
    {
        public Odemeler Odemeler { get; set; }
        public List<Police> Police { get; internal set; }
        public List<MusteriModel> MusterilerList { get; internal set; }
    }
}
