using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class DetallesCompraRequest
    {
        public int IdDetalleCompra { get; set; }
        public int? IdCompra { get; set; }
        public int? IdInsumo { get; set; }
        public double? Cantidad { get; set; }
        public double? Descuento { get; set; }
        public double? PrecioUnitario { get; set; }
    }
}
