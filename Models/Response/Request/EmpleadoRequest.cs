using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class EmpleadoRequest
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public int? IdPuestoTrabajo { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int? Estado { get; set; }

    }
}
