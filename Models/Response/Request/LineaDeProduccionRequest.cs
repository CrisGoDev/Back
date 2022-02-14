using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class LineaDeProduccioneRequest
    {
        public int IdLineaDeProduccion { get; set; }
        public int? IdProducto { get; set; }
        public string DescripcionLinea { get; set; }
        public string DescripcionProducto { get; set; }

        public DetalleLineaDeProduccioneRequest [] detalleLinea { get; set; }
    }
}
