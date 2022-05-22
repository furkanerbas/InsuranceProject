using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace InsureApp.Models
{
    public class PoliceUpdateViewModel
    {
        public Police Police { get; set; }
        public List<Police_Turu> PoliceTuru { get; set; }
        public List<Musteri> Musteri { get; set; }

    }
}
