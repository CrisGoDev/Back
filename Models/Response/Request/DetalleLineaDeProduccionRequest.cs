using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class DetalleLineaDeProduccioneRequest
    {
        public int IdDetalleLineaDeProduccion { get; set; }
        public int? IdLineaDeProduccion { get; set; }
        public int? IdInsumo { get; set; }
        public double? Cantidad { get; set; }
    }
}
