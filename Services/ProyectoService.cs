using NCPHARMACY.Models;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Models.Response.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Services
{
    public class ProyectoService:IProyectoService
    {
            public void Add(ProyectoRequest model)
            {
                Respuestas respuesta = new Respuestas();

                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    using (var transaccion = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Proyecto proyect = new Proyecto();
                            proyect.Nombre = model.Nombre;
                            proyect.Descripcion = model.Descripcion;
                            proyect.Estado = model.Estado;

                            db.Proyectos.Add(proyect);
                            db.SaveChanges();

                            for (int i = 0; i < model.detallesProyecto.Length; i++)
                            {
                                DetalleProyecto deta = new DetalleProyecto();
                                deta.IdProyecto = proyect.IdProyecto;
                                deta.InversionTotal = model.detallesProyecto.ElementAt(i).InversionTotal;
                                deta.VidaUtil = model.detallesProyecto.ElementAt(i).VidaUtil;
                                deta.IdTipoPeridos = model.detallesProyecto.ElementAt(i).IdTipoPeridos;
                                deta.IdTipoDepreciacion = model.detallesProyecto.ElementAt(i).IdTipoDepreciacion;
                                deta.ValorSalvamento = model.detallesProyecto.ElementAt(i).ValorSalvamento;
                                deta.VidaUtilMaquinaEquipo = model.detallesProyecto.ElementAt(i).VidaUtilMaquinaEquipo;
                                deta.UnidadesPrimerPeriodo = model.detallesProyecto.ElementAt(i).UnidadesPrimerPeriodo;
                                deta.DecrementoUnidades = model.detallesProyecto.ElementAt(i).DecrementoUnidades;
                                deta.TasaRecaudacionSaldo = model.detallesProyecto.ElementAt(i).TasaRecaudacionSaldo;
                                deta.Financiamiento = model.detallesProyecto.ElementAt(i).Financiamiento;
                                deta.PlazoPrestamo = model.detallesProyecto.ElementAt(i).PlazoPrestamo;
                                deta.TazaDeIntereses = model.detallesProyecto.ElementAt(i).TazaDeIntereses;
                                deta.IdTipoAmortizacion = model.detallesProyecto.ElementAt(i).IdTipoAmortizacion;
                                deta.Ingresos = model.detallesProyecto.ElementAt(i).Ingresos;
                                deta.IdTipoCrecimientoIngresos = model.detallesProyecto.ElementAt(i).IdTipoCrecimientoIngresos;
                                deta.CrecimientoIngreso = model.detallesProyecto.ElementAt(i).CrecimientoIngreso;
                                deta.TasaImpositiva = model.detallesProyecto.ElementAt(i).TasaImpositiva;
                                deta.Tmarinversionista = model.detallesProyecto.ElementAt(i).Tmarinversionista;


                                db.DetalleProyectos.Add(deta);
                                db.SaveChanges();
                            for (int k=0;k<model.detallesProyecto.ElementAt(i).detallesCostos.Length;k++)
                            {
                                DetalleProyectoCosto detalle = new DetalleProyectoCosto();
                                detalle.IdDetalleProyecto = model.detallesProyecto.ElementAt(i).IdDetalleProyecto;
                                detalle.NombreCosto = model.detallesProyecto.ElementAt(i).detallesCostos.ElementAt(k).NombreCosto;
                                detalle.TipoCrecimiento = model.detallesProyecto.ElementAt(i).detallesCostos.ElementAt(k).TipoCrecimiento;
                                detalle.Crecimiento = model.detallesProyecto.ElementAt(i).detallesCostos.ElementAt(k).Crecimiento;

                                db.DetalleProyectoCostos.Add(detalle);
                                db.SaveChanges();
                            }
                            for (int k = 0; k < model.detallesProyecto.ElementAt(i).detallesGastos.Length; k++)
                            {
                                DetalleProyectoGasto detalle = new DetalleProyectoGasto();
                                detalle.IdDetalleProyecto = model.detallesProyecto.ElementAt(i).IdDetalleProyecto;
                                detalle.NombreGasto = model.detallesProyecto.ElementAt(i).detallesGastos.ElementAt(k).NombreGasto;
                                detalle.TipoCrecimiento = model.detallesProyecto.ElementAt(i).detallesGastos.ElementAt(k).TipoCrecimiento;
                                detalle.Crecimiento = model.detallesProyecto.ElementAt(i).detallesGastos.ElementAt(k).Crecimiento;

                                db.DetalleProyectoGastos.Add(detalle);
                                db.SaveChanges();
                            }

                            }

                            transaccion.Commit();
                        }
                        catch (Exception)
                        {
                            transaccion.Rollback();
                            throw new Exception("Ocurrio un error en la insercion");
                            ;
                        }
                    }
                }
            }
        }
    }