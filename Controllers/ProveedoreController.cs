using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Models;
using NCPHARMACY.Models.Response.Request;

namespace NCPHARMACY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoreController : ControllerBase
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
                    var lst = db.Proveedores.OrderBy(d => d.IdProveedor).ToList();
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
        public ActionResult Add(ProveedorRequest oModel)
        {
            
            Respuestas respuesta = new Respuestas();
           
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    Proveedore prov = new Proveedore();
                    prov.IdProveedor = oModel.IdProveedor;
                    prov.NombreCompleto = oModel.NombreCompleto;
                    prov.Cedula = oModel.Cedula;
                    prov.Telefono = oModel.Telefono;
                    prov.Correo = oModel.Correo;
                    prov.Direccion = oModel.Direccion;
                    db.Proveedores.Add(prov);
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
        public ActionResult Edit(ProveedorRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdProveedor == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    Proveedore prov = db.Proveedores.Find(oModel.IdProveedor);

                    prov.NombreCompleto = oModel.NombreCompleto;
                    prov.Cedula = oModel.Cedula;
                    prov.Telefono = oModel.Telefono;
                    prov.Correo = oModel.Correo;
                    prov.Direccion = oModel.Direccion;
                    db.Entry(prov).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        //            Proveedore prov = db.Proveedores.Find(id);

        //            db.Remove(prov);
        //            db.SaveChanges();
        //            respuesta.Exito = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        respuesta.Mensaje = ex.Message;
        //    }
        //    respuesta.Mensaje = id;
        //    return Ok(respuesta);
        //}

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
                    Proveedore prov = db.Proveedores.Find(id);

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
    }
}
