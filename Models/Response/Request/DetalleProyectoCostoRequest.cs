using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class DetalleProyectoCostoRequest
    {

        public int IdTipoCosto { get; set; }
        public int? IdDetalleProyecto { get; set; }
        public string NombreCosto { get; set; }
        public int? TipoCrecimiento { get; set; }
        public double? Crecimiento { get; set; }
    }
}
