using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsureApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace InsureApp.Models
{
    public class PoliceAddViewListModel
    {
        public Police Police { get; set; }
        public List<Police_Turu> PoliceTuru { get; internal set; }
        public List<MusteriModel> MusterilerList { get; internal set; }
        public Arac Arac { get; set; }

    }
}
