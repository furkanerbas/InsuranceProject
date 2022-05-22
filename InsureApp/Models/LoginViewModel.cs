using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsureApp.Models
{
    [Table("AspNetUsers")] // abi bi çalıştırayım gör istersen ?ok
    public class LoginViewModel
    {
        [Required] // abi tablo arıyorsan yok codefirst yaklasımı ile
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
