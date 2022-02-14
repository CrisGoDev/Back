using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DetalleLineaDeProduccione
    {
        public int IdDetalleLineaDeProduccion { get; set; }
        public int? IdLineaDeProduccion { get; set; }
        public int? IdInsumo { get; set; }
        public double? Cantidad { get; set; }

        public virtual Insumo IdInsumoNavigation { get; set; }
        public virtual LineaDeProduccione IdLineaDeProduccionNavigation { get; set; }
    }
}
