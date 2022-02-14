using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.EvaluacionProyectos
{
    public class FlujoNetoEfectivo
    {
        public double Ingresos { get; set; }
        public double CostosDeProduccion { get; set; }
        public double CostosFijos { get; set; }
        public double CostosVariable { get; set; }
        public double GastosAdministrativos { get; set; }
        public double GastosDeVenta { get; set; }
        public double GastosFinancieros { get; set; }
        public double DepreciacionDeActivosFijos { get; set; }
        public double AmortizacionDeActivosDiferidos { get; set; }
        public double UtilidadAntesDelIR { get; set; }
        public double DepreciacionDeActivosFijos2 { get; set; }
        public double AmortizacionDeActivosDiferidos2 { get; set; }
        public double ValorDeRescate { get; set; }
        public double RecuperacionDeCapitalDeTrabajo { get; set; }
        public double   Prestamo { get; set; }
        public double Inversion { get; set; }
        public double AbonoAlPrincipal { get; set; }
        public double FlujoNetoDeEfectivo { get; set; }
    }
}
