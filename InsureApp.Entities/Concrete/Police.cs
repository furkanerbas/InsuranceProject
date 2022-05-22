using InsureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace InsureApp.Entities.Concrete
{
    public class Police : IEntity
    {
        [Key]
        public int Police_no { get; set; }
        public int Musteri_id { get; set; }
        public int Policetur_id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Baslangic_tarihi { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Bitis_tarihi { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Vize_tarihi { get; set; }
        public int Sigorta_bedeli  { get; set; }
        
    }

}
