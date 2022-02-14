using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            DetalleProyectos = new HashSet<DetalleProyecto>();
        }

        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public virtual EstadoProyecto EstadoNavigation { get; set; }
        public virtual ICollection<DetalleProyecto> DetalleProyectos { get; set; }
    }
}
