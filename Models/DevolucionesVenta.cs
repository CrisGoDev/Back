using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DevolucionesVenta
    {
        public int IdDevolucionVenta { get; set; }
        public int? IdDetalleVenta { get; set; }
        public double? Cantidad { get; set; }

        public virtual DetalleDeVenta IdDetalleVentaNavigation { get; set; }
    }
}
