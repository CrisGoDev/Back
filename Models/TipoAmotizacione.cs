using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoAmotizacione
    {
        public TipoAmotizacione()
        {
            DetalleProyectos = new HashSet<DetalleProyecto>();
        }

        public int IdTipoAmortizacion { get; set; }
        public string TipoAmortizacion { get; set; }

        public virtual ICollection<DetalleProyecto> DetalleProyectos { get; set; }
    }
}
