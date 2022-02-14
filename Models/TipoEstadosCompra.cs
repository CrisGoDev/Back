using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoEstadosCompra
    {
        public TipoEstadosCompra()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdTipoEstadoCompra { get; set; }
        public string TipoEstadosCompra1 { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
