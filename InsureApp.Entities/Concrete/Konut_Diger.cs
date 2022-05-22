using InsureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsureApp.Entities.Concrete
{
    public class Konut_Diger : IEntity
    {
        [Key]
        public int Konut_id { get; set; }
        public string Adres { get; set; }
        public int Police_no { get; set; }
    }
}
