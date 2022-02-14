using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Compras = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public int? IdPuestoTrabajo { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int? Estado { get; set; }

        public virtual TipoEstadoEmpleado EstadoNavigation { get; set; }
        public virtual PuestosDeTrabajo IdPuestoTrabajoNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
