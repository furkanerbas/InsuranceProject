using InsureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;


namespace InsureApp.Entities.Concrete
{
    public class Odemeler : IEntity
    {
        [Key]
        public int Odeme_id { get; set; }
        public int Police_no { get; set; }
        public int Musteri_id { get; set; }
        public int Odenen_tutar { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Odeme_tarihi { get;set;}

    }
}
