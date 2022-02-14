using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TiposPeriodo
    {
        public TiposPeriodo()
        {
            DetalleProyectos = new HashSet<DetalleProyecto>();
        }

        public int IdTipoPeridos { get; set; }
        public string TipoPerido { get; set; }

        public virtual ICollection<DetalleProyecto> DetalleProyectos { get; set; }
    }
}
