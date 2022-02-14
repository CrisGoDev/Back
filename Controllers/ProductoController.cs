using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCPHARMACY.Models;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Models.Response.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCPHARMACY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Respuestas respuesta = new Respuestas();
            respuesta.Exito = 0;
            try
            {

                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    var lst = db.Productos.ToList();
                    respuesta.Exito = 1;
                    respuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }


        [HttpPost]
        public ActionResult Add(ProductoRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    Producto prod = new Producto();
                    prod.IdProducto = oModel.IdProducto;
                    prod.Nombre = oModel.Nombre;
                    prod.Cantidad = oModel.Cantidad;
                    prod.Descripcion = oModel.Descripcion;
                    prod.Precio = oModel.Precio;
                    db.Productos.Add(prod);
                    db.SaveChanges();

                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }



        [HttpPut]
        public ActionResult Edit(ProductoRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdProducto == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    Producto prod = db.Productos.Find(oModel.IdProducto);

                    prod.Nombre = oModel.Nombre;
                    prod.Cantidad = oModel.Cantidad;
                    prod.Descripcion = oModel.Descripcion;
                    prod.Precio = oModel.Precio;
                    db.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    respuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Respuestas respuesta = new Respuestas();
            if (id == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    Producto prov = db.Productos.Find(id);

                    db.Remove(prov);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            respuesta.Mensaje = id.ToString();
            return Ok(respuesta);
        }

        //[HttpDelete("{id}")]
        //public ActionResult Delete(String id)
        //{
        //    Respuestas respuesta = new Respuestas();
        //    if (id == null)
        //    {
        //        respuesta.Mensaje = "nulo";
        //        return Ok(respuesta);
        //    }
        //    try
        //    {
        //        using (NCPHARMACYContext db = new NCPHARMACYContext())
        //        {
        //            Producto prov = db.Productos.Find(id);

        //            db.Remove(prov);
        //            db.SaveChanges();
        //            respuesta.Exito = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        respuesta.Mensaje = ex.Message;
        //    }
        //    respuesta.Mensaje = "mamauev";
        //    return Ok(respuesta);
        //}
    }
}
