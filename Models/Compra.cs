using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Compra
    {
        public Compra()
        {
            DetallesCompras = new HashSet<DetallesCompra>();
        }

        public int IdCompra { get; set; }
        public int? IdEmpleado { get; set; }
        public double? Total { get; set; }
        public double? Descuento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdTipoEstadoCrompa { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual TipoEstadosCompra IdTipoEstadoCrompaNavigation { get; set; }
        public virtual ICollection<DetallesCompra> DetallesCompras { get; set; }
    }
}
