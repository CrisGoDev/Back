using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class PuestosDeTrabajo
    {
        public PuestosDeTrabajo()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdPuestoDeTrabajo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
