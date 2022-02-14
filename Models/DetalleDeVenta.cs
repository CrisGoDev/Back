using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DetalleDeVenta
    {
        public DetalleDeVenta()
        {
            DevolucionesVenta = new HashSet<DevolucionesVenta>();
        }

        public int IdDetalleDeVentas { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public double? PrecioUnitario { get; set; }
        public double? Cantidad { get; set; }
        public double? Descuento { get; set; }
        public double? Total { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
        public virtual ICollection<DevolucionesVenta> DevolucionesVenta { get; set; }
    }
}
