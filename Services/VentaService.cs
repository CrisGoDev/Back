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
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
            Respuestas respuesta = new Respuestas();

            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Venta venta = new Venta();
                        venta.IdDistribuidora = model.IdDistribuidora;
                        venta.IdEmpleado = model.IdEmpleado;
                        venta.Fecha = model.Fecha;
                        venta.Descuento = model.Descuento;
                        venta.Total = model.detallesVenta.Sum(d => d.Cantidad * d.PrecioUnitario);
                        venta.Estado = model.Estado;

                        db.Ventas.Add(venta);
                        db.SaveChanges();
                        List<Venta> lista = db.Ventas.OrderBy(d => d.IdVenta).ToList();

                        for (int i = 0; i < model.detallesVenta.Length; i++)
                        {
                            DetalleDeVenta deta = new DetalleDeVenta();
                            deta.IdVenta = lista.ElementAt(lista.Count-1).IdVenta;
                            deta.IdProducto = model.detallesVenta.ElementAt(i).IdProducto;
                            deta.PrecioUnitario = model.detallesVenta.ElementAt(i).PrecioUnitario;
                            deta.Cantidad = model.detallesVenta.ElementAt(i).Cantidad;
                            deta.Descuento = model.detallesVenta.ElementAt(i).Descuento;
                            deta.Total = model.detallesVenta.ElementAt(i).Total;

                            ProductoRequest productoRequest = new ProductoRequest();
                            Producto producto = db.Productos.Find(model.detallesVenta.ElementAt(i).IdProducto);
                            ProductoController controller = new ProductoController();
                            if (producto.Cantidad < model.detallesVenta.ElementAt(i).Cantidad)
                            {
                                transaccion.Rollback();
                                transaccion.Commit();
                                return;
                            }
                            else if (producto.Cantidad >= model.detallesVenta.ElementAt(i).Cantidad)
                            {
                                productoRequest.IdProducto = producto.IdProducto;
                                productoRequest.Nombre = producto.Nombre;
                                productoRequest.Cantidad = producto.Cantidad-model.detallesVenta.ElementAt(i).Cantidad;
                                productoRequest.Descripcion = producto.Descripcion;
                                productoRequest.Precio = producto.Precio;
                                controller.Edit(productoRequest);
                            }


                            db.DetalleDeVentas.Add(deta);
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

        public void Edit(VentaRequest oModel)
        {

            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Venta comp = db.Ventas.Find(oModel.IdVenta);

                        comp.IdDistribuidora = oModel.IdDistribuidora;
                        comp.IdEmpleado = oModel.IdEmpleado;
                        comp.Fecha = oModel.Fecha;
                        comp.Descuento = oModel.Descuento;
                        comp.Total = oModel.Total;
                        comp.Estado = oModel.Estado;


                        db.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();

                        List<DetalleDeVenta> listaFalsa = db.DetalleDeVentas.OrderBy(d => d.IdDetalleDeVentas).ToList();
                        List<DetalleDeVenta> listadetalleDeVentas = new List<DetalleDeVenta>();
                        for (int k=0;k<listaFalsa.Count;k++)
                        {
                            if (listaFalsa.ElementAt(k).IdVenta==oModel.IdVenta)
                            {
                                listadetalleDeVentas.Add(listaFalsa.ElementAt(k));
                            }
                        }

                        for (int i = 0; i < oModel.detallesVenta.Length; i++)
                        {
                            DetalleDeVenta detalle = db.DetalleDeVentas.Find(oModel.detallesVenta.ElementAt(i).IdDetalleDeVentas);
                            detalle.IdVenta = oModel.detallesVenta.ElementAt(i).IdVenta;
                            detalle.IdProducto = oModel.detallesVenta.ElementAt(i).IdProducto;
                            detalle.PrecioUnitario = oModel.detallesVenta.ElementAt(i).PrecioUnitario;
                            detalle.Cantidad = oModel.detallesVenta.ElementAt(i).Cantidad;
                            detalle.Descuento = oModel.detallesVenta.ElementAt(i).Descuento;
                            detalle.Total = oModel.detallesVenta.ElementAt(i).Total;



                            ProductoRequest productoRequest = new ProductoRequest();
                            Producto producto = db.Productos.Find(oModel.detallesVenta.ElementAt(i).IdProducto);
                            ProductoController controller = new ProductoController();
                            if ((listadetalleDeVentas.ElementAt(i).IdDetalleDeVentas==oModel.detallesVenta.ElementAt(i).IdDetalleDeVentas)&&
                                (listadetalleDeVentas.ElementAt(i).Cantidad <= oModel.detallesVenta.ElementAt(i).Cantidad))
                            {
                                productoRequest.IdProducto = producto.IdProducto;
                                productoRequest.Nombre = producto.Nombre;
                                productoRequest.Cantidad = producto.Cantidad - (oModel.detallesVenta.ElementAt(i).Cantidad-listadetalleDeVentas.ElementAt(i).Cantidad);
                                productoRequest.Descripcion = producto.Descripcion;
                                productoRequest.Precio = producto.Precio;

                                if ((producto.Cantidad - (oModel.detallesVenta.ElementAt(i).Cantidad - listadetalleDeVentas.ElementAt(i).Cantidad))<0)
                                {                          
                                    //La cantidad de productos es insuficiente
                                    transaccion.Rollback();
                                    transaccion.Commit();
                                    return;
                                }

                                controller.Edit(productoRequest);
                            }
                            else if ((listadetalleDeVentas.ElementAt(i).IdDetalleDeVentas == oModel.detallesVenta.ElementAt(i).IdDetalleDeVentas) &&
                                (listadetalleDeVentas.ElementAt(i).Cantidad > oModel.detallesVenta.ElementAt(i).Cantidad))
                            {
                                productoRequest.IdProducto = producto.IdProducto;
                                productoRequest.Nombre = producto.Nombre;
                                productoRequest.Cantidad = producto.Cantidad + (listadetalleDeVentas.ElementAt(i).Cantidad-oModel.detallesVenta.ElementAt(i).Cantidad);
                                productoRequest.Descripcion = producto.Descripcion;
                                productoRequest.Precio = producto.Precio;
                                controller.Edit(productoRequest);
                            }



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
                        Venta prov = db.Ventas.Find(id);
                        List<DetalleDeVenta> detalles = db.DetalleDeVentas.OrderBy(d => d.IdDetalleDeVentas).ToList();
                        for (int i = 0; i < detalles.Count; i++)
                        {
                            DetalleDeVenta det = detalles.ElementAt(i);
                            if (det.IdVenta == prov.IdVenta)
                            {

                                ProductoRequest productoRequest = new ProductoRequest();
                                Producto producto = db.Productos.Find(detalles.ElementAt(i).IdProducto);
                                ProductoController productoController = new ProductoController();
                                productoRequest.IdProducto = producto.IdProducto;
                                productoRequest.Nombre = producto.Nombre;
                                productoRequest.Cantidad = producto.Cantidad + detalles.ElementAt(i).Cantidad;
                                productoRequest.Descripcion = producto.Descripcion;
                                productoRequest.Precio = producto.Precio;

                                productoController.Edit(productoRequest);

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