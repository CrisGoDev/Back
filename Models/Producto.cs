using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleDeVenta = new HashSet<DetalleDeVenta>();
            LineaDeProducciones = new HashSet<LineaDeProduccione>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double? Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }

        public virtual ICollection<DetalleDeVenta> DetalleDeVenta { get; set; }
        public virtual ICollection<LineaDeProduccione> LineaDeProducciones { get; set; }
    }
}
