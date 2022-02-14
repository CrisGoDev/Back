using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class InsumoRequest
    {
        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public int? IdProveedor { get; set; }
        public string Descripcion { get; set; }
        public double? Cantidad { get; set; }
    }
}
