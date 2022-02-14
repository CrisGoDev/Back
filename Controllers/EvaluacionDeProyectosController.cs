using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionDeProyectosController : ControllerBase
    {
        public List<List<double>> Calendario(double prestamo, double tasa, int vida)
        {
            List<List<double>> lista = new List<List<double>>();
            List<double> saldo = new List<double>();
            List<double> interes = new List<double>();
            List<double> abono = new List<double>();
            List<double> cuota = new List<double>();
            saldo.Add(prestamo);
            interes.Add(0);
            abono.Add(0);
            cuota.Add(0);
            double PMV = (prestamo * (tasa) / (1 - Math.Pow((1 + tasa), -(vida))));
            for (int i = 0; i < vida; i++)
            {
                interes.Add(saldo.ElementAt(i) * tasa);
                abono.Add(PMV);
                cuota.Add(-interes.ElementAt(i + 1) + abono.ElementAt(i + 1));
                saldo.Add(saldo.ElementAt(i) - cuota.ElementAt(i + 1));

            }
            lista.Add(saldo);
            lista.Add(interes);
            lista.Add(abono);
            lista.Add(cuota);
            return lista;
        }
        public void DataSource(DataTable dt, int fila)
        {
            int vida = Convert.ToInt32(dt.Rows[fila].ToString());
            double prestamo = (Convert.ToDouble(dt.Rows[fila][2].ToString()) / 100) * Convert.ToDouble(dt.Rows[fila][1].ToString());
            double tasaprestamo = Convert.ToDouble(dt.Rows[fila][3].ToString()) / 100;
            List<double> ingresos = new List<double>();
            List<double> costosProd = new List<double>();
            List<double> gastrosadmin = new List<double>();
            List<double> gastosventa = new List<double>();
            List<double> depreciacion = new List<double>();
            List<double> intereses = Calendario(prestamo, tasaprestamo, vida).ElementAt(1);
            List<double> UAI = new List<double>();
            List<double> impuestos = new List<double>();
            List<double> UDI = new List<double>();
            List<double> abonodeuda = Calendario(prestamo, tasaprestamo, vida).ElementAt(2);
            List<double> valorsalvamento = new List<double>();
            List<double> prestamolist = new List<double>();
            List<double> inversion = new List<double>();
            List<double> FNEE = new List<double>();
            ingresos.Add(0);
            ingresos.Add(Convert.ToDouble(dt.Rows[fila][6].ToString()));
            costosProd.Add(0);
            costosProd.Add(Convert.ToDouble(dt.Rows[fila][8].ToString()));
            gastrosadmin.Add(0);
            gastrosadmin.Add(Convert.ToDouble(dt.Rows[fila][10].ToString()));
            gastosventa.Add(0);
            gastosventa.Add(Convert.ToDouble(dt.Rows[fila][11].ToString()));
            depreciacion.Add(0);
            depreciacion.Add(Convert.ToDouble(dt.Rows[fila][1].ToString()) * (Convert.ToDouble(dt.Rows[fila][12].ToString()) / 100));
            UAI.Add(0);
            UAI.Add(ingresos.ElementAt(1) - costosProd.ElementAt(1) - gastrosadmin.ElementAt(1) - gastosventa.ElementAt(1) - depreciacion.ElementAt(1) - intereses.ElementAt(1));
            impuestos.Add(0);
            impuestos.Add(UAI.ElementAt(1) * 0.3);
            UDI.Add(0);
            UDI.Add(UAI.ElementAt(1) * 0.7);
            valorsalvamento.Add(0);
            valorsalvamento.Add(0);
            prestamolist.Add(prestamo);
            prestamolist.Add(0);
            inversion.Add(Convert.ToDouble(dt.Rows[fila][1].ToString()));
            inversion.Add(0);
            FNEE.Add(prestamolist.ElementAt(0) - inversion.ElementAt(0));
            FNEE.Add(UDI.ElementAt(1) + depreciacion.ElementAt(1) - abonodeuda.ElementAt(1) + valorsalvamento.ElementAt(1));
            double increIngresos = Convert.ToDouble(dt.Rows[fila][7].ToString()) / 100;
            double increcosts = Convert.ToDouble(dt.Rows[fila][9].ToString()) / 100;
            for (int i = 1; i < vida; i++)
            {
                ingresos.Add(ingresos.ElementAt(i) * (1 + increIngresos));
                costosProd.Add(costosProd.ElementAt(i) * (1 + increcosts));
                gastrosadmin.Add(Convert.ToDouble(dt.Rows[fila][10].ToString()));
                gastosventa.Add(Convert.ToDouble(dt.Rows[fila][11].ToString()));
                depreciacion.Add(Convert.ToDouble(dt.Rows[fila][1].ToString()) * (Convert.ToDouble(dt.Rows[fila][12].ToString()) / 100));
                UAI.Add(ingresos.ElementAt(i + 1) - costosProd.ElementAt(i + 1) - gastrosadmin.ElementAt(i + 1) - gastosventa.ElementAt(i + 1) - depreciacion.ElementAt(i + 1) - intereses.ElementAt(i + 1));
                impuestos.Add(UAI.ElementAt(i + 1) * 0.3);
                UDI.Add(UAI.ElementAt(i + 1) * 0.7);
                if (i == (vida - 1))
                {
                    valorsalvamento.Add((Convert.ToDouble(dt.Rows[fila][13].ToString()) / 100) * (Convert.ToDouble(dt.Rows[fila][1].ToString())));
                }
                else
                {
                    valorsalvamento.Add(0);
                }
                prestamolist.Add(0);
                inversion.Add(0);
                FNEE.Add(UDI.ElementAt(i + 1) + depreciacion.ElementAt(i + 1) - abonodeuda.ElementAt(i + 1) + valorsalvamento.ElementAt(i + 1));
            }
            DataSet dataSet1 = new DataSet();

            dataSet1.Tables[1].Rows.Clear();
            for (int i = 0; i < 15; i++)
            {
                DataRow dr = dataSet1.Tables[1].NewRow();
                dataSet1.Tables[1].Rows.Add(dr);
            }
            //Ingresos, CostosDeProduccion, CostosFijos,CostosVariable,GastosAdministrativos,GastosDeVenta,GastosFinancieros, DepreciacionDeActivosFijos 
        //AmortizacionDeActivosDiferidos, UtilidadAntesDelIR, DepreciacionDeActivosFijos2,AmortizacionDeActivosDiferidos2,ValorDeRescate        
            //RecuperacionDeCapitalDeTrabajo,Prestamo,Inversion, AbonoAlPrincipal, FlujoNetoDeEfectivo
        dataSet1.Tables[1].Rows[0][0] = "INGRESOS";
            dataSet1.Tables[1].Rows[1][0] = "COSTOS PRODUCCION";
            dataSet1.Tables[1].Rows[2][0] = "GASTOS ADMINISTRATIVOS";
            dataSet1.Tables[1].Rows[3][0] = "GASTOS VENTAS";
            dataSet1.Tables[1].Rows[4][0] = "GASTOS DEPRECIACION";
            dataSet1.Tables[1].Rows[5][0] = "INTERESS";
            dataSet1.Tables[1].Rows[6][0] = "UTILIDAD ANTES DE IMPU";
            dataSet1.Tables[1].Rows[7][0] = "IMPUESTOS";
            dataSet1.Tables[1].Rows[8][0] = "UTILIDAD DESP DE IMPU";
            dataSet1.Tables[1].Rows[9][0] = "DEPRECIACION";
            dataSet1.Tables[1].Rows[10][0] = "ABONO A LA DEUDA";
            dataSet1.Tables[1].Rows[11][0] = "VALOR RESIDUAL";
            dataSet1.Tables[1].Rows[12][0] = "PRESTAMO";
            dataSet1.Tables[1].Rows[13][0] = "INVERION";
            dataSet1.Tables[1].Rows[14][0] = "FNE";
            for (int i = 1; i <= vida; i++)
            {
                dataSet1.Tables[1].Rows[0][i] = Math.Round(ingresos.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[1][i] = Math.Round(costosProd.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[2][i] = Math.Round(gastrosadmin.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[3][i] = Math.Round(gastosventa.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[4][i] = Math.Round(depreciacion.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[5][i] = Math.Round(intereses.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[6][i] = Math.Round(UAI.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[7][i] = Math.Round(impuestos.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[8][i] = Math.Round(UDI.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[9][i] = Math.Round(depreciacion.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[10][i] = Math.Round(abonodeuda.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[11][i] = Math.Round(valorsalvamento.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[12][i] = Math.Round(prestamolist.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[13][i] = Math.Round(inversion.ElementAt(i), 4);
                dataSet1.Tables[1].Rows[14][i] = Math.Round(FNEE.ElementAt(i), 4);

            }
            /*

            FNE fne = new FNE();
            fne.dt = dataSet1.Tables[1];
            fne.tasa = TMARMIXTA(tasaprestamo, (Convert.ToDouble(dt.Rows[fila][2].ToString()) / 100), (Convert.ToDouble(dt.Rows[fila][15].ToString()) / 100));
            fne.LISTA = FNEE;
            fne.vida = vida;
            fne.Show();*/
        }
        }

    }
