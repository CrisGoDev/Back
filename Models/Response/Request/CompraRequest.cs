using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class CompraRequest
    {
        public int IdCompra { get; set; }
        public int? IdEmpleado { get; set; }
        public double? Total { get; set; }
        public double? Descuento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdTipoEstadoCrompa { get; set; }

        public DetallesCompraRequest[] detallesCompras{get;set;}
    }
}
