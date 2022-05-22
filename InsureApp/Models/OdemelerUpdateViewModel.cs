using InsureApp.Entities.Concrete;
using System.Collections.Generic;

namespace InsureApp.Models
{
    public class OdemelerUpdateViewModel
    {
        public Odemeler Odemeler { get; set; }
        public List<Musteri> Musteri { get; set; }
        public List<Police> Police { get; set; }
    }
}