using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Pronosticos
{
    public class Regresiones
    {
        private double indiceRegresionLineal { get; set; }
        private double indiceRegresionLogaritmica { get; set; }
        private double indiceRegresionPotencial { get; set; }
        private double indiceRegresionExponencial { get; set; }

        public Regresiones(List<List<double>> puntos)
        {
         indiceRegresionLineal = 0;
         indiceRegresionLogaritmica = 0;
         indiceRegresionPotencial = 0;
         indiceRegresionExponencial = 0;
            Correlacion(puntos);
        }        
        public void Correlacion(List<List<double>> puntos)
        {
            double sumaXMedia = 0,sumaYMedia=0,sumaXproducto=0,sumaXind=0, sumaYind=0;
            for (int i=0;i<puntos.Count;i++)
            {
                sumaXMedia = sumaXMedia + puntos.ElementAt(i).ElementAt(0);
                sumaYMedia = sumaYMedia + puntos.ElementAt(i).ElementAt(1);
            }
            sumaXMedia = sumaXMedia / puntos.Count;
            sumaYMedia = sumaYMedia / puntos.Count;

            for (int y=0;y<puntos.Count;y++)
            {
                sumaXproducto = sumaXproducto + (puntos.ElementAt(y).ElementAt(0)-sumaXMedia) * (puntos.ElementAt(y).ElementAt(0) - sumaYMedia);
                sumaXind = sumaXind+(puntos.ElementAt(y).ElementAt(0) - sumaXMedia) * (puntos.ElementAt(y).ElementAt(0) - sumaXMedia) ;
                sumaYind = sumaYind + (puntos.ElementAt(y).ElementAt(0) - sumaYMedia) * (puntos.ElementAt(y).ElementAt(0) - sumaYMedia);
            }

            indiceRegresionLineal = Math.Abs((sumaXproducto) / (Math.Pow((sumaYind * sumaXind), 0.5)));

            List<List<double>> listaLogar = new List<List<double>>();
            List<double> punto;

            for (int i = 0; i < listaLogar.Count; i++)
            {
                punto = new List<double>();
                punto.Add(Math.Log(listaLogar.ElementAt(i).ElementAt(0), Math.E));
                punto.Add(listaLogar.ElementAt(i).ElementAt(0));
                listaLogar.Add(punto);
            }
            sumaXind = 0;
            sumaYind = 0;
            sumaXMedia = 0;
            sumaYMedia = 0;
            sumaXproducto = 0;

            for (int i = 0; i < listaLogar.Count; i++)
            {
                sumaXMedia = sumaXMedia + listaLogar.ElementAt(i).ElementAt(0);
                sumaYMedia = sumaYMedia + listaLogar.ElementAt(i).ElementAt(1);
            }
            sumaXMedia = sumaXMedia / listaLogar.Count;
            sumaYMedia = sumaYMedia / listaLogar.Count;

            for (int y = 0; y < listaLogar.Count; y++)
            {
                sumaXproducto = sumaXproducto + (listaLogar.ElementAt(y).ElementAt(0) - sumaXMedia) * (listaLogar.ElementAt(y).ElementAt(0) - sumaYMedia);
                sumaXind = sumaXind + (listaLogar.ElementAt(y).ElementAt(0) - sumaXMedia) * (listaLogar.ElementAt(y).ElementAt(0) - sumaXMedia);
                sumaYind = sumaYind + (listaLogar.ElementAt(y).ElementAt(0) - sumaYMedia) * (listaLogar.ElementAt(y).ElementAt(0) - sumaYMedia);
            }
            indiceRegresionLogaritmica= Math.Abs((sumaXproducto) / (Math.Pow((sumaYind * sumaXind), 0.5)));


            List<List<double>> listaPotencial = new List<List<double>>();
            List<double> punto3;
            for (int i = 0; i < puntos.Count; i++)
            {
                punto3= new List<double>();
                punto3.Add(Math.Log(puntos.ElementAt(i).ElementAt(0)));
                punto3.Add(Math.Log(puntos.ElementAt(i).ElementAt(1)));
                listaPotencial.Add(punto3);
            }

            sumaXind = 0;
            sumaYind = 0;
            sumaXMedia = 0;
            sumaYMedia = 0;
            sumaXproducto = 0;

            for (int i = 0; i < listaPotencial.Count; i++)
            {
                sumaXMedia = sumaXMedia + listaPotencial.ElementAt(i).ElementAt(0);
                sumaYMedia = sumaYMedia + listaPotencial.ElementAt(i).ElementAt(1);
            }
            sumaXMedia = sumaXMedia / listaPotencial.Count;
            sumaYMedia = sumaYMedia / listaPotencial.Count;

            for (int y = 0; y < listaPotencial.Count; y++)
            {
                sumaXproducto = sumaXproducto + (listaPotencial.ElementAt(y).ElementAt(0) - sumaXMedia) * (listaPotencial.ElementAt(y).ElementAt(0) - sumaYMedia);
                sumaXind = sumaXind + (listaPotencial.ElementAt(y).ElementAt(0) - sumaXMedia) * (listaPotencial.ElementAt(y).ElementAt(0) - sumaXMedia);
                sumaYind = sumaYind + (listaPotencial.ElementAt(y).ElementAt(0) - sumaYMedia) * (listaPotencial.ElementAt(y).ElementAt(0) - sumaYMedia);
            }
            indiceRegresionPotencial= Math.Abs((sumaXproducto) / (Math.Pow((sumaYind * sumaXind), 0.5)));

            List<List<double>> listaExponencial = new List<List<double>>();
            List<double> punto4;
            for (int i = 0; i < puntos.Count; i++)
            {
                punto4 = new List<double>();
                punto4.Add(puntos.ElementAt(i).ElementAt(0));
                punto4.Add(Math.Log(puntos.ElementAt(i).ElementAt(1), Math.E));
                listaExponencial.Add(punto4);
            }

            sumaXind = 0;
            sumaYind = 0;
            sumaXMedia = 0;
            sumaYMedia = 0;
            sumaXproducto = 0;

            for (int i = 0; i < listaExponencial.Count; i++)
            {
                sumaXMedia = sumaXMedia + listaExponencial.ElementAt(i).ElementAt(0);
                sumaYMedia = sumaYMedia + listaExponencial.ElementAt(i).ElementAt(1);
            }
            sumaXMedia = sumaXMedia / listaExponencial.Count;
            sumaYMedia = sumaYMedia / listaExponencial.Count;

            for (int y = 0; y < listaExponencial.Count; y++)
            {
                sumaXproducto = sumaXproducto + (listaExponencial.ElementAt(y).ElementAt(0) - sumaXMedia) * (listaExponencial.ElementAt(y).ElementAt(0) - sumaYMedia);
                sumaXind = sumaXind + (listaExponencial.ElementAt(y).ElementAt(0) - sumaXMedia) * (listaExponencial.ElementAt(y).ElementAt(0) - sumaXMedia);
                sumaYind = sumaYind + (listaExponencial.ElementAt(y).ElementAt(0) - sumaYMedia) * (listaExponencial.ElementAt(y).ElementAt(0) - sumaYMedia);
            }
            indiceRegresionExponencial= Math.Abs((sumaXproducto) / (Math.Pow((sumaYind * sumaXind), 0.5)));
        }
        public double IndiceDeCorrelacion()
        {
            List<double> lista = new List<double>();
            lista.Add(indiceRegresionLineal);
            lista.Add(indiceRegresionLogaritmica);
            lista.Add(indiceRegresionPotencial);
            lista.Add(indiceRegresionExponencial);
            double max = lista.ElementAt(0); double min = lista.ElementAt(6);
            int indice = 11;
            bool menor = false;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int k = 0; k < lista.Count; k++)
                {
                    if ((lista.ElementAt(k) > lista.ElementAt(i)) && k != i)
                    {
                        menor = true;
                    }
                    else
                    {
                        menor = false;
                        break;
                    }
                }
                if (menor == true)
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }
        public List<List<double>> RegresionAdecuada(List<List<double>> puntos, int numeroPuntosQueQuieres, int desdeX1, int hastaX2)
        {
            List<List<double>> lista = new List<List<double>>(); 
            switch (IndiceDeCorrelacion())
            {
                case 0:
                    lista= RegresionLineal(puntos, numeroPuntosQueQuieres, desdeX1, hastaX2);
                    break;
                case 1:
                    break;
                    lista = RegresionLogaritmica(puntos, numeroPuntosQueQuieres, desdeX1, hastaX2);
                case 2:
                    lista = RegresionPotencial(puntos, numeroPuntosQueQuieres, desdeX1, hastaX2);
                    break;
                case 3:
                    lista = RegresionExponencial(puntos, numeroPuntosQueQuieres, desdeX1, hastaX2);
                    break;
                default:
                    return lista;
            }
            return lista;
        }

        public List<List<double>> RegresionLineal(List<List<double>> puntos, int numeroPuntosQueQuieres, int desdeX1, int hastaX2)
        {
            List<List<double>> lineaRegresion = new List<List<double>>();
            double a = 0, b = 0, sumaX = 0, sumaY = 0, sumaXX = 0, sumaYY = 0, sumaXY = 0;
            for (int i = 0; i < puntos.Count; i++)
            {
                sumaX = sumaX + puntos.ElementAt(i).ElementAt(0);
                sumaY = sumaY + puntos.ElementAt(i).ElementAt(1);
                sumaXX = sumaXX + puntos.ElementAt(i).ElementAt(0) * puntos.ElementAt(i).ElementAt(0);
                sumaYY = sumaYY + puntos.ElementAt(i).ElementAt(1) * puntos.ElementAt(i).ElementAt(1);
                sumaXY = sumaXY + puntos.ElementAt(i).ElementAt(1) * puntos.ElementAt(i).ElementAt(0);
            }
            b = (sumaXY - sumaX * sumaY / puntos.Count) / (sumaXX - (sumaX * sumaX) / puntos.Count);
            a = (sumaY / puntos.Count) - b * (sumaX / puntos.Count);

            List<double> punto;
            double incremento = (hastaX2 - desdeX1) / (numeroPuntosQueQuieres-1);
            for (int i=0;i<numeroPuntosQueQuieres;i++)
            {
                punto = new List<double>();
                punto.Add(desdeX1+incremento*i);
                punto.Add(a+b*(desdeX1+incremento*i));
                lineaRegresion.Add(punto);
            }
            return lineaRegresion;
        }
            
        public List<List<double>> RegresionLogaritmica(List<List<double>> puntos, int numeroPuntosQueQuieres, int desdeX1, int hastaX2)
        {
            List<List<double>> listaLogar = new List<List<double>>();
            List<double> punto;
            
            for (int i=0;i<puntos.Count;i++)
            {
                punto = new List<double>();                
                punto.Add(Math.Log(puntos.ElementAt(i).ElementAt(0),Math.E));
                punto.Add(puntos.ElementAt(i).ElementAt(0));
                listaLogar.Add(punto);
            }
            List<List<double>>lista= RegresionLineal(listaLogar,numeroPuntosQueQuieres,desdeX1,hastaX2);
            List<List<double>> original = new List<List<double>>();
            List<double> punt;
            for (int k = 0; k < lista.Count; k++)
            {
                punt = new List<double>();                
                punt.Add(Math.Pow(Math.E,lista.ElementAt(k).ElementAt(0)));
                punt.Add(lista.ElementAt(k).ElementAt(1));
                original.Add(punt);
            }

            return original;
        }
        public List<List<double>> RegresionPotencial(List<List<double>> puntos, int numeroPuntosQueQuieres, int desdeX1, int hastaX2)
        {
            List<List<double>> listaPotencial = new List<List<double>>();
            List<double> punto ;
            for (int i = 0; i < puntos.Count;i++)
            {
                punto= new List<double>();
                punto.Add(Math.Log(puntos.ElementAt(i).ElementAt(0)));
                punto.Add(Math.Log(puntos.ElementAt(i).ElementAt(1)));
                listaPotencial.Add(punto);
            }

            List<List<double>> datos = RegresionLineal(puntos,numeroPuntosQueQuieres,desdeX1,hastaX2);

            List<List<double>> original = new List<List<double>>();
            List<double> punto2;
            for (int i=0;i<datos.Count;i++)
            {
                punto2 = new List<double>();
                punto2.Add(Math.Pow(Math.E, datos.ElementAt(i).ElementAt(0)));
                punto2.Add(Math.Pow(Math.E, datos.ElementAt(i).ElementAt(1)));
                original.Add(punto2);
            }

            return original;
        }

        public List<List<double>> RegresionExponencial(List<List<double>> puntos, int numeroPuntosQueQuieres, int desdeX1, int hastaX2)
        {
            List<List<double>> listaExponencial = new List<List<double>>();
            List<double> punto;
            for (int i = 0; i < puntos.Count; i++)
            {
                punto = new List<double>();
                punto.Add(puntos.ElementAt(i).ElementAt(0));
                punto.Add(Math.Log(puntos.ElementAt(i).ElementAt(1), Math.E));
                listaExponencial.Add(punto);
            }
            List<List<double>> lista = RegresionLineal(listaExponencial, numeroPuntosQueQuieres, desdeX1, hastaX2);
            List<double> punto2;
            List<List<double>> listaOriginal = new List<List<double>>();
            for (int i = 0; i < lista.Count; i++)
            {
                punto2 = new List<double>();
                punto2.Add(lista.ElementAt(i).ElementAt(0));
                punto2.Add(Math.Pow(lista.ElementAt(i).ElementAt(0), Math.E));
                listaOriginal.Add(punto2);
            }
            return listaOriginal;
        }

    }
}
