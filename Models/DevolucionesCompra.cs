using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DevolucionesCompra
    {
        public int IdDevolucionesCompra { get; set; }
        public int? IdDetalleCompra { get; set; }
        public double? Cantidad { get; set; }

        public virtual DetallesCompra IdDetalleCompraNavigation { get; set; }
    }
}
