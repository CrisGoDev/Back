using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class LineaDeProduccione
    {
        public LineaDeProduccione()
        {
            DetalleLineaDeProducciones = new HashSet<DetalleLineaDeProduccione>();
        }

        public int IdLineaDeProduccion { get; set; }
        public int? IdProducto { get; set; }
        public string DescripcionLinea { get; set; }
        public string DescripcionProducto { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdTipoEstadoProduccion { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual TipoEstadoProduccion IdTipoEstadoProduccionNavigation { get; set; }
        public virtual ICollection<DetalleLineaDeProduccione> DetalleLineaDeProducciones { get; set; }
    }
}
