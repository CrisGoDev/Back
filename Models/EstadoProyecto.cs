using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class EstadoProyecto
    {
        public EstadoProyecto()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdEstadoProyecto { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
