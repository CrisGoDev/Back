﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
    }
}
