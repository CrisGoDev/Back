using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class VentaRequest
    {
        public int IdVenta { get; set; }
        public int? IdDistribuidora { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Descuento { get; set; }
        public double? Total { get; set; }
        public int? Estado { get; set; }
        public DetalleDeVentaRequest[] detallesVenta { get; set; }
    }
    public class DetalleDeVentaRequest
    {
        public int IdDetalleDeVentas { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public double? PrecioUnitario { get; set; }
        public double? Cantidad { get; set; }
        public double? Descuento { get; set; }
        public double? Total { get; set; }
    }
}
