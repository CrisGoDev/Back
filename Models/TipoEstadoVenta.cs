using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoEstadoVenta
    {
        public TipoEstadoVenta()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdTipoEstadoVentas { get; set; }
        public string TipoEstadoVenta1 { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
