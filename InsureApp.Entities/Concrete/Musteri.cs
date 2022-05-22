using InsureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsureApp.Entities.Concrete
{
    public class Musteri: IEntity
    {
        [Key]
        public int Musteri_id { get; set; }
        [Required]
        public long Tc_No { get; set; }
        [Required]
        public string Isim { get; set; }
        [Required]
        public string Soyisim { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long Tel_no { get; set; }
        [Required]
        public string Adres { get; set; }
        public string Ozel_not { get; set; }
    }
}
