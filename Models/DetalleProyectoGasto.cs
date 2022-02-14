using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DetalleProyectoGasto
    {
        public int IdTipoGasto { get; set; }
        public int? IdDetalleProyecto { get; set; }
        public string NombreGasto { get; set; }
        public int? TipoCrecimiento { get; set; }
        public double? Crecimiento { get; set; }
        public double? ValorInicial { get; set; }

        public virtual DetalleProyecto IdDetalleProyectoNavigation { get; set; }
        public virtual TipoCrecimiento TipoCrecimientoNavigation { get; set; }
    }
}
