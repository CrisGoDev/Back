using System;
using System.Collections.Generic;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class DetalleProyecto
    {
        public DetalleProyecto()
        {
            DetalleProyectoCostos = new HashSet<DetalleProyectoCosto>();
            DetalleProyectoGastos = new HashSet<DetalleProyectoGasto>();
        }

        public int IdDetalleProyecto { get; set; }
        public int? IdProyecto { get; set; }
        public double InversionTotal { get; set; }
        public int VidaUtil { get; set; }
        public int? IdTipoPeridos { get; set; }
        public int? IdTipoDepreciacion { get; set; }
        public double? ValorSalvamento { get; set; }
        public int? VidaUtilMaquinaEquipo { get; set; }
        public double? UnidadesPrimerPeriodo { get; set; }
        public double? DecrementoUnidades { get; set; }
        public double? TasaRecaudacionSaldo { get; set; }
        public double? Financiamiento { get; set; }
        public double? PlazoPrestamo { get; set; }
        public double? TazaDeIntereses { get; set; }
        public int? IdTipoAmortizacion { get; set; }
        public double? Ingresos { get; set; }
        public int? IdTipoCrecimientoIngresos { get; set; }
        public double? CrecimientoIngreso { get; set; }
        public double? TasaImpositiva { get; set; }
        public double? Tmarinversionista { get; set; }
        public double? ValorMaquinariaYequipo { get; set; }
        public double? CapitalDeTrabajo { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual TipoAmotizacione IdTipoAmortizacionNavigation { get; set; }
        public virtual TipoCrecimiento IdTipoCrecimientoIngresosNavigation { get; set; }
        public virtual TipoDepreciacione IdTipoDepreciacionNavigation { get; set; }
        public virtual TiposPeriodo IdTipoPeridosNavigation { get; set; }
        public virtual ICollection<DetalleProyectoCosto> DetalleProyectoCostos { get; set; }
        public virtual ICollection<DetalleProyectoGasto> DetalleProyectoGastos { get; set; }
    }
}
