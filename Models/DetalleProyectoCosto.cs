using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DetalleProyectoCosto
    {
        public int IdTipoCosto { get; set; }
        public int? IdDetalleProyecto { get; set; }
        public string NombreCosto { get; set; }
        public int? TipoCrecimiento { get; set; }
        public double? Crecimiento { get; set; }
        public double? ValorInicial { get; set; }

        public virtual DetalleProyecto IdDetalleProyectoNavigation { get; set; }
        public virtual TipoCrecimiento TipoCrecimientoNavigation { get; set; }
    }
}
