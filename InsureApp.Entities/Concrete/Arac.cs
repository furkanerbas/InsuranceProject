using InsureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsureApp.Entities.Concrete
{
    public class Arac : IEntity
    {
        [Key]
        public int Arac_id { get; set; }
        public string Arac_turu { get; set; }
        public string Plaka { get; set; }
        public string Ruhsat_no { get; set; }
        public int Police_no { get; set; }
    }
}
