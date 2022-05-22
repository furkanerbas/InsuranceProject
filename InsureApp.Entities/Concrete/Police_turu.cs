using InsureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsureApp.Entities.Concrete
{
    public class Police_Turu : IEntity
    {
        [Key]
        public int Policetur_id { get; set; }
        public string Police_turu { get; set; }
    }
}
