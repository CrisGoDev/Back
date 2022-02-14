using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoDepreciacione
    {
        public TipoDepreciacione()
        {
            DetalleProyectos = new HashSet<DetalleProyecto>();
        }

        public int IdTipoDepreciacion { get; set; }
        public string TipoDepreciacion { get; set; }

        public virtual ICollection<DetalleProyecto> DetalleProyectos { get; set; }
    }
}
