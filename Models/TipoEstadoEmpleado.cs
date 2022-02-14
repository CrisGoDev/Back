using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class TipoEstadoEmpleado
    {
        public TipoEstadoEmpleado()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdTipoEstadoEmpleado { get; set; }
        public string TipoEstadoEmpleado1 { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
