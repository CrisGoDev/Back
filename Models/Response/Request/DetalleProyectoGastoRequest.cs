using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class DetalleProyectoGastoRequest
    {

        public int IdTipoGasto { get; set; }
        public int? IdDetalleProyecto { get; set; }
        public string NombreGasto { get; set; }
        public int? TipoCrecimiento { get; set; }
        public double? Crecimiento { get; set; }

    }
}
