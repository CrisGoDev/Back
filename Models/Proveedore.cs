using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Insumos = new HashSet<Insumo>();
        }

        public int IdProveedor { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Insumo> Insumos { get; set; }
    }
}
