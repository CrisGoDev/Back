using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoEstadoProduccion
    {
        public TipoEstadoProduccion()
        {
            LineaDeProducciones = new HashSet<LineaDeProduccione>();
        }

        public int IdTipoEstadoProduccion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<LineaDeProduccione> LineaDeProducciones { get; set; }
    }
}
