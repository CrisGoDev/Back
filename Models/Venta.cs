using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleDeVenta = new HashSet<DetalleDeVenta>();
        }

        public int IdVenta { get; set; }
        public int? IdDistribuidora { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Descuento { get; set; }
        public double? Total { get; set; }
        public int? Estado { get; set; }

        public virtual TipoEstadoVenta EstadoNavigation { get; set; }
        public virtual Distribuidora IdDistribuidoraNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<DetalleDeVenta> DetalleDeVenta { get; set; }
    }
}
