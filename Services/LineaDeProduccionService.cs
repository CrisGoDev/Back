using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCPHARMACY.Controllers;
using NCPHARMACY.Models;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Models.Response.Request;

namespace NCPHARMACY.Services
{
    public class LineaDeProduccionService
    {
        public void Add(LineaDeProduccioneRequest model)
        {
            Respuestas respuesta = new Respuestas();

            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        LineaDeProduccione linea = new LineaDeProduccione();
                        linea.IdProducto = model.IdProducto;
                        linea.DescripcionLinea = model.DescripcionLinea;
                        linea.DescripcionProducto = model.DescripcionProducto;                      

                        db.LineaDeProducciones.Add(linea);
                        db.SaveChanges();


                        List<LineaDeProduccione> lista = db.LineaDeProducciones.OrderBy(d => d.IdLineaDeProduccion).ToList();
                        for (int i = 0; i < model.detalleLinea.Length; i++)
                        {
                            DetalleLineaDeProduccione deta = new DetalleLineaDeProduccione();
                            deta.IdLineaDeProduccion = lista.ElementAt(lista.Count-1).IdLineaDeProduccion;
                            deta.IdInsumo = model.detalleLinea.ElementAt(i).IdInsumo;
                            deta.Cantidad = model.detalleLinea.ElementAt(i).Cantidad;

                            db.DetalleLineaDeProducciones.Add(deta);
                            db.SaveChanges();
                        }

                        //Apartir de aqui comienza la validacion

                        List<LineaDeProduccione> lineas = db.LineaDeProducciones.OrderBy(d => d.IdLineaDeProduccion).ToList();

                        List<DetalleLineaDeProduccione> lista2 = db.DetalleLineaDeProducciones.OrderBy(d => d.IdDetalleLineaDeProduccion).ToList();
                        List<DetalleLineaDeProduccione> listaDetalle = new List<DetalleLineaDeProduccione>();
                        for (int i = 0; i < lista2.Count; i++)
                        {
                            if (lineas.ElementAt(lineas.Count - 1).IdLineaDeProduccion == lista2.ElementAt(i).IdLineaDeProduccion)
                            {
                                listaDetalle.Add(lista2.ElementAt(i));
                            }
                        }

                        List<Insumo> listaInsumo = db.Insumos.OrderBy(d => d.IdInsumo).ToList();

                        InsumoRequest request = new InsumoRequest();
                        InsumoController controlador = new InsumoController();
                        for (int i = 0; i < listaDetalle.Count; i++)
                        {
                            for (int k = 0; k < listaInsumo.Count; k++)
                            {
                                if (listaInsumo.ElementAt(k).IdInsumo == listaDetalle.ElementAt(i).IdInsumo)
                                {
                                    if (listaDetalle.ElementAt(i).Cantidad <= listaInsumo.ElementAt(k).Cantidad)
                                    {

                                        request.IdInsumo = listaInsumo.ElementAt(k).IdInsumo;
                                        request.Nombre = listaInsumo.ElementAt(k).Nombre;
                                        request.IdProveedor = listaInsumo.ElementAt(k).IdProveedor;
                                        request.Descripcion = listaInsumo.ElementAt(k).Descripcion;
                                        request.Cantidad = listaInsumo.ElementAt(k).Cantidad - listaDetalle.ElementAt(i).Cantidad;
                                        controlador.Edit(request);
                                    }
                                    else
                                    {
                                        transaccion.Rollback();
                                        transaccion.Commit();
                                        //Esto significa que la cantidad de insumos es inferior a la solicitada
                                        return;
                                    }
                                }
                            }
                        }


                        List<Producto> listaProd = db.Productos.OrderBy(d => d.IdProducto).ToList();
                        int indice = 0;
                        for (int i = 0; i < listaProd.Count; i++)
                        {
                            if (listaProd.ElementAt(i).IdProducto == model.IdProducto)
                            {
                                indice = i;
                            }
                        }

                        ProductoController productoController = new ProductoController();
                        ProductoRequest request1 = new ProductoRequest();

                        request1.IdProducto = listaProd.ElementAt(indice).IdProducto;
                        request1.Nombre = listaProd.ElementAt(indice).Nombre;
                        request1.Cantidad = listaProd.ElementAt(indice).Cantidad + 1000;//Cada vez que se ejecuta una linea de produccion esta genera 1000 nuevos paquetes 
                        request1.Descripcion = listaProd.ElementAt(indice).Descripcion;//Para el producto que se ejecuta
                        request1.Precio = listaProd.ElementAt(indice).Precio;
                        productoController.Edit(request1);

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


        public void Edit(LineaDeProduccioneRequest oModel)
        {

            using (NCPHARMACYContext db = new NCPHARMACYContext())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        LineaDeProduccione comp = db.LineaDeProducciones.Find(oModel.IdLineaDeProduccion);

                        comp.IdProducto = oModel.IdProducto;
                        comp.DescripcionLinea = oModel.DescripcionLinea;
                        comp.DescripcionProducto = oModel.DescripcionProducto;
                        db.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();


                        List<DetalleLineaDeProduccione> listaFalsa = db.DetalleLineaDeProducciones.OrderBy(d => d.IdDetalleLineaDeProduccion).ToList();
                        List<DetalleLineaDeProduccione> detalleLineaDeProducciones = new List<DetalleLineaDeProduccione>();
                        for (int y=0;y<listaFalsa.Count;y++)
                        {
                            if (oModel.IdLineaDeProduccion==listaFalsa.ElementAt(y).IdLineaDeProduccion)
                            {
                                detalleLineaDeProducciones.Add(listaFalsa.ElementAt(y));
                            }
                        }

                        List<Insumo> listaInsumo = db.Insumos.OrderBy(d => d.IdInsumo).ToList();
                        for (int i = 0; i < oModel.DescripcionLinea.Length; i++)
                        {
                            for (int k = 0; k < listaInsumo.Count; k++)
                            {
                                InsumoRequest request = new InsumoRequest();
                                InsumoController controller = new InsumoController();
                                if (oModel.detalleLinea.ElementAt(i).IdInsumo == listaInsumo.ElementAt(k).IdInsumo)
                                {
                                    if ((oModel.detalleLinea.ElementAt(i).IdLineaDeProduccion==detalleLineaDeProducciones.ElementAt(i).IdLineaDeProduccion)&&
                                        (oModel.detalleLinea.ElementAt(i).Cantidad <= detalleLineaDeProducciones.ElementAt(i).Cantidad))
                                    {
                                        request.IdInsumo = listaInsumo.ElementAt(k).IdInsumo;
                                        request.Nombre = listaInsumo.ElementAt(k).Nombre;
                                        request.IdProveedor = listaInsumo.ElementAt(k).IdProveedor;
                                        request.Descripcion = listaInsumo.ElementAt(k).Descripcion;
                                        request.Cantidad = listaInsumo.ElementAt(k).Cantidad + detalleLineaDeProducciones.ElementAt(i).Cantidad-oModel.detalleLinea.ElementAt(i).Cantidad;
                                        controller.Edit(request);

                                    }else if ((oModel.detalleLinea.ElementAt(i).IdLineaDeProduccion == detalleLineaDeProducciones.ElementAt(i).IdLineaDeProduccion) &&
                                        (oModel.detalleLinea.ElementAt(i).Cantidad > detalleLineaDeProducciones.ElementAt(i).Cantidad))
                                    {
                                        request.IdInsumo = listaInsumo.ElementAt(k).IdInsumo;
                                        request.Nombre = listaInsumo.ElementAt(k).Nombre;
                                        request.IdProveedor = listaInsumo.ElementAt(k).IdProveedor;
                                        request.Descripcion = listaInsumo.ElementAt(k).Descripcion;
                                        
                                        if ((oModel.detalleLinea.ElementAt(i).Cantidad- detalleLineaDeProducciones.ElementAt(i).Cantidad)>listaInsumo.ElementAt(k).Cantidad)
                                        {
                                            //La cantidad de insumos es superior a la existencia
                                            transaccion.Rollback();
                                            transaccion.Commit();
                                            return;
                                        }
                                        else
                                        {
                                            request.Cantidad = listaInsumo.ElementAt(k).Cantidad - detalleLineaDeProducciones.ElementAt(i).Cantidad + oModel.detalleLinea.ElementAt(i).Cantidad;
                                            controller.Edit(request);
                                        }
                                    }
                                }
                            }
                        }


                        for (int i = 0; i < oModel.detalleLinea.Length; i++)
                        {
                            DetalleLineaDeProduccione detalle = db.DetalleLineaDeProducciones.Find(oModel.detalleLinea.ElementAt(i).IdDetalleLineaDeProduccion);
                            detalle.IdLineaDeProduccion = oModel.detalleLinea.ElementAt(i).IdLineaDeProduccion;
                            detalle.IdInsumo = oModel.detalleLinea.ElementAt(i).IdInsumo;
                            detalle.Cantidad = oModel.detalleLinea.ElementAt(i).Cantidad;

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
                        List<DetalleLineaDeProduccione> detalles = db.DetalleLineaDeProducciones.OrderBy(d => d.IdDetalleLineaDeProduccion).ToList();
                        InsumoController insumoController = new InsumoController();

                        for (int i = 0; i < detalles.Count; i++)
                        {
                            InsumoRequest insumo = new InsumoRequest();
                            Insumo insumo1 = db.Insumos.Find(detalles.ElementAt(i).IdInsumo);
                            insumo.IdInsumo = insumo1.IdInsumo;
                            insumo.Nombre = insumo1.Nombre;
                            insumo.IdProveedor = insumo1.IdProveedor;
                            insumo.Descripcion = insumo1.Descripcion;
                            insumo.Cantidad = insumo1.Cantidad + detalles.ElementAt(i).Cantidad;
                            insumoController.Edit(insumo);

                        }
                        LineaDeProduccione prov = db.LineaDeProducciones.Find(id);
                        
                        for (int i = 0; i < detalles.Count; i++)
                        {
                            DetalleLineaDeProduccione det = detalles.ElementAt(i);
                            if (det.IdLineaDeProduccion == prov.IdLineaDeProduccion)
                            {
                                db.Remove(det);
                                db.SaveChanges();
                            }
                        }

                        Producto producto = db.Productos.Find(prov.IdProducto);
                        ProductoRequest productoRequest = new ProductoRequest();
                        ProductoController productoController = new ProductoController();

                        productoRequest.IdProducto = producto.IdProducto;
                        productoRequest.Nombre = producto.Nombre;
                        
                        productoRequest.Descripcion = producto.Descripcion;
                        productoRequest.Precio = producto.Precio;

                        if (producto.Cantidad<1000)
                        {
                            productoRequest.Cantidad = 0;
                        }
                        else
                        {
                            productoRequest.Cantidad = producto.Cantidad-1000;
                        }
                        productoController.Edit(productoRequest);
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