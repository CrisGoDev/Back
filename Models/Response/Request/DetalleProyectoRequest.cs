using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Models.Response.Request
{
    public class DetalleProyectoRequest
    {
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


        public DetalleProyectoCostoRequest[] detallesCostos;
        public DetalleProyectoGastoRequest[] detallesGastos;

    }
}
