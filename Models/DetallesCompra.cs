using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DetallesCompra
    {
        public DetallesCompra()
        {
            DevolucionesCompras = new HashSet<DevolucionesCompra>();
        }

        public int IdDetalleCompra { get; set; }
        public int? IdCompra { get; set; }
        public int? IdInsumo { get; set; }
        public double? Cantidad { get; set; }
        public double? Descuento { get; set; }
        public double? PrecioUnitario { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Insumo IdInsumoNavigation { get; set; }
        public virtual ICollection<DevolucionesCompra> DevolucionesCompras { get; set; }
    }
}
