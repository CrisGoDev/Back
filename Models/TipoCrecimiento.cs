using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoCrecimiento
    {
        public TipoCrecimiento()
        {
            DetalleProyectoCostos = new HashSet<DetalleProyectoCosto>();
            DetalleProyectoGastos = new HashSet<DetalleProyectoGasto>();
            DetalleProyectos = new HashSet<DetalleProyecto>();
        }

        public int IdTipoCrecimiento { get; set; }
        public string TipoCrecimiento1 { get; set; }

        public virtual ICollection<DetalleProyectoCosto> DetalleProyectoCostos { get; set; }
        public virtual ICollection<DetalleProyectoGasto> DetalleProyectoGastos { get; set; }
        public virtual ICollection<DetalleProyecto> DetalleProyectos { get; set; }
    }
}
