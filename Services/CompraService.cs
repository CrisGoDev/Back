using NCPHARMACY.Controllers;
using NCPHARMACY.Models;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Models.Response.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Services
{
    public class CompraService
    {

        public void Add(CompraRequest model)
        {
            Respuestas respuesta = new Respuestas();

            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        //La siguiente modificacion se realizo el 15/09/2021
                        Compra compra = new Compra();
                        compra.IdEmpleado = model.IdEmpleado;
                        compra.Total = model.detallesCompras.Sum(d => d.Cantidad * d.PrecioUnitario);
                        compra.Descuento = model.Descuento* model.detallesCompras.Sum(d => d.Cantidad * d.PrecioUnitario);
                        compra.Fecha = model.Fecha;
                        compra.IdTipoEstadoCrompa = model.IdTipoEstadoCrompa;

                        //En esta parte se validan la existencias de insumos suficientes
                        List<Insumo> listaInsumos = db.Insumos.OrderBy(d=>d.IdInsumo).ToList();
                        for (int j = 0; j < listaInsumos.Count; j++)
                        {
                            for (int i = 0; i < model.detallesCompras.Length; i++)
                            {
                                if (listaInsumos.ElementAt(j).IdInsumo==model.detallesCompras.ElementAt(i).IdInsumo)
                                {
                                    if (listaInsumos.ElementAt(j).Cantidad<model.detallesCompras.ElementAt(i).Cantidad)
                                    {
                                        respuesta.Mensaje="La cantidad de Insumos "+listaInsumos.ElementAt(j).Nombre+" Es insuficiente";
                                        transaccion.Rollback();                                        
                                        return ;
                                    }else if (listaInsumos.ElementAt(j).Cantidad >= model.detallesCompras.ElementAt(i).Cantidad)
                                    {
                                        InsumoController controlador = new InsumoController();
                                        InsumoRequest insu = new InsumoRequest();
                                        insu.IdInsumo = listaInsumos.ElementAt(j).IdInsumo;
                                        insu.Nombre = listaInsumos.ElementAt(j).Nombre;
                                        insu.Descripcion = listaInsumos.ElementAt(j).Descripcion;
                                        insu.Cantidad = listaInsumos.ElementAt(j).Cantidad-model.detallesCompras.ElementAt(i).Cantidad;
                                        controlador.Edit(insu);
                                    }                                    
                                }
                            }
                        }

                        db.Compras.Add(compra);
                        db.SaveChanges();
                        List<Compra> lista = db.Compras.OrderBy(d => d.IdCompra).ToList();
                        for (int i = 0; i < model.detallesCompras.Length; i++)
                        {
                            DetallesCompra deta = new DetallesCompra();
                            deta.IdCompra = lista.ElementAt(lista.Count-1).IdCompra;
                            deta.IdInsumo = model.detallesCompras.ElementAt(i).IdInsumo;
                            deta.Cantidad = model.detallesCompras.ElementAt(i).Cantidad;
                            deta.Descuento = model.detallesCompras.ElementAt(i).Descuento;
                            deta.PrecioUnitario = model.detallesCompras.ElementAt(i).PrecioUnitario;
                
                            db.DetallesCompras.Add(deta);
                            db.SaveChanges();
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

        public void Edit(CompraRequest oModel)
        {
            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        List<DetallesCompra> detaCompra = db.DetallesCompras.OrderBy(d => d.IdCompra).ToList();
                        List<DetallesCompra> detaCompraSecundaria = new List<DetallesCompra>();
                        for (int i=0;i<detaCompra.Count;i++)
                        {
                            if (detaCompra.ElementAt(i).IdCompra==oModel.IdCompra)
                            {
                                detaCompraSecundaria.Add(detaCompra.ElementAt(i));
                            }
                        }

                        Compra comp = db.Compras.Find(oModel.IdCompra);

                        comp.IdEmpleado = oModel.IdEmpleado;
                        comp.Total = oModel.Total;
                        comp.Descuento = oModel.Descuento;
                        comp.Fecha = oModel.Fecha;
                        comp.IdTipoEstadoCrompa = oModel.IdTipoEstadoCrompa;

                        db.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();

                        InsumoController controlador = new InsumoController();
                        
                        for (int i = 0; i < oModel.detallesCompras.Length; i++)
                        {
                            DetallesCompra detalle = db.DetallesCompras.Find(oModel.detallesCompras.ElementAt(i).IdDetalleCompra);
                            detalle.IdCompra = oModel.IdCompra;
                            if ((oModel.detallesCompras.ElementAt(i).IdDetalleCompra==detaCompraSecundaria.ElementAt(i).IdDetalleCompra) && 
                                (oModel.detallesCompras.ElementAt(i).Cantidad > detaCompraSecundaria.ElementAt(i).Cantidad))
                            {
                                InsumoRequest insumo = new InsumoRequest();
                                int indice = 0;
                                List<Insumo> listaInsumos = db.Insumos.OrderBy(d => d.IdInsumo).ToList();
                                for (int k=0;k<listaInsumos.Count;k++)
                                {
                                    if (listaInsumos.ElementAt(k).IdInsumo==oModel.detallesCompras.ElementAt(i).IdInsumo)
                                    {
                                        indice = k;
                                    }
                                }

                                insumo.IdInsumo = listaInsumos.ElementAt(indice).IdInsumo;
                                insumo.Nombre = listaInsumos.ElementAt(indice).Nombre;
                                insumo.IdProveedor = listaInsumos.ElementAt(indice).IdProveedor;
                                insumo.Descripcion = listaInsumos.ElementAt(indice).Descripcion;
                                
                                insumo.Cantidad = listaInsumos.ElementAt(indice).Cantidad- (oModel.detallesCompras.ElementAt(i).Cantidad - detaCompraSecundaria.ElementAt(i).Cantidad);
                                    controlador.Edit(insumo);                                                        

                                
                            }else if ((oModel.detallesCompras.ElementAt(i).IdDetalleCompra == detaCompraSecundaria.ElementAt(i).IdDetalleCompra) &&
                                (oModel.detallesCompras.ElementAt(i).Cantidad < detaCompraSecundaria.ElementAt(i).Cantidad))
                            {
                                InsumoRequest insumo = new InsumoRequest();
                                int indice = 0;
                                List<Insumo> listaInsumos = db.Insumos.OrderBy(d => d.IdInsumo).ToList();
                                for (int k = 0; k < listaInsumos.Count; k++)
                                {
                                    if (listaInsumos.ElementAt(k).IdInsumo == oModel.detallesCompras.ElementAt(i).IdInsumo)
                                    {
                                        indice = k;
                                    }
                                }

                                insumo.IdInsumo = listaInsumos.ElementAt(indice).IdInsumo;
                                insumo.Nombre = listaInsumos.ElementAt(indice).Nombre;
                                insumo.IdProveedor = listaInsumos.ElementAt(indice).IdProveedor;
                                insumo.Descripcion = listaInsumos.ElementAt(indice).Descripcion;

                                insumo.Cantidad = listaInsumos.ElementAt(indice).Cantidad + (-oModel.detallesCompras.ElementAt(i).Cantidad + detaCompraSecundaria.ElementAt(i).Cantidad);
                                controlador.Edit(insumo);
                            }
                            detalle.IdInsumo = oModel.detallesCompras.ElementAt(i).IdInsumo;
                            detalle.Cantidad = oModel.detallesCompras.ElementAt(i).Cantidad;
                            detalle.Descuento = oModel.detallesCompras.ElementAt(i).Descuento;
                            detalle.PrecioUnitario = oModel.detallesCompras.ElementAt(i).PrecioUnitario;
                            

                            db.Entry(detalle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            db.SaveChanges();
                        }

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Ocurrio un error en la actualizacion");
                    }

                }

            }
        }
        public void Delete(int id)
        {
            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {

                        Compra prov = db.Compras.Find(id);
                        List<DetallesCompra> detalles = db.DetallesCompras.OrderBy(d => d.IdDetalleCompra).ToList();
                        List<Insumo> listaInsu = db.Insumos.OrderBy(d=>d.IdInsumo).ToList();
                        InsumoController controlador = new InsumoController();
                        for (int i = 0; i < detalles.Count; i++)
                        {
                            DetallesCompra det = detalles.ElementAt(i);
                            if (det.IdCompra == prov.IdCompra)
                            {
                                for (int k = 0; k < listaInsu.Count; k++)
                                {
                                    if (det.IdInsumo == listaInsu.ElementAt(i).IdInsumo)
                                    {
                                        InsumoRequest insumo = new InsumoRequest();
                                        insumo.IdInsumo = listaInsu.ElementAt(i).IdInsumo;
                                        insumo.Nombre = listaInsu.ElementAt(i).Nombre;
                                        insumo.IdProveedor = listaInsu.ElementAt(i).IdProveedor;
                                        insumo.Descripcion = listaInsu.ElementAt(i).Descripcion;
                                        insumo.Cantidad = listaInsu.ElementAt(i).Cantidad+det.Cantidad;

                                        controlador.Edit(insumo);
                                        break;
                                    }
                                }
                                db.Remove(det);
                                db.SaveChanges();
                            }
                        }
                        db.Remove(prov);
                        db.SaveChanges();

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Ocurrio un error en la Eliminacion");
                    }
                }
            }
        }
    }
}
