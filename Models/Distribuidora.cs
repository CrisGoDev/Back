using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Distribuidora
    {
        public Distribuidora()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdDistribuidora { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
