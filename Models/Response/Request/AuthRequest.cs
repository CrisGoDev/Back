using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class AuthRequest
    {
        public int IdUsuario { get; set; }
        [Required]
        public string Correo { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string Contraseña { get; set; }
    }
}
