using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;

namespace InsureApp.Models
{
    public class PoliceModel:Police
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string FullName { get; set; }
        public string PoliceTuru { get; set; }
        public int Odeme { get; set; }

    }
}
