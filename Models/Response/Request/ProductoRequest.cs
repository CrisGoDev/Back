using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class ProductoRequest
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double? Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
    }
}
