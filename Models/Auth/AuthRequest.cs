using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Auth
{
    public class AuthRequest
    {

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
