using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class Insumo
    {
        public Insumo()
        {
            DetalleLineaDeProducciones = new HashSet<DetalleLineaDeProduccione>();
            DetallesCompras = new HashSet<DetallesCompra>();
        }

        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public int? IdProveedor { get; set; }
        public string Descripcion { get; set; }
        public double? Cantidad { get; set; }
        public double? PrecioUnitario { get; set; }

        public virtual Proveedore IdProveedorNavigation { get; set; }
        public virtual ICollection<DetalleLineaDeProduccione> DetalleLineaDeProducciones { get; set; }
        public virtual ICollection<DetallesCompra> DetallesCompras { get; set; }
    }
}
