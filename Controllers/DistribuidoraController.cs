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
    public class DistribuidoraController : ControllerBase
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
                    var lst = db.Distribuidoras.OrderBy(d => d.IdDistribuidora).ToList();
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
        public ActionResult Add(DistribuidoraRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    Distribuidora distri = new Distribuidora();

                    distri.Nombre = oModel.Nombre;
                    distri.Direccion = oModel.Direccion;
                    distri.Correo = oModel.Correo;
                    distri.Telefono = oModel.Telefono;

                    db.Distribuidoras.Add(distri);
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
        public ActionResult Edit(DistribuidoraRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdDistribuidora == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    Distribuidora distri = db.Distribuidoras.Find(oModel.IdDistribuidora);
                    distri.Nombre = oModel.Nombre;
                    distri.Direccion = oModel.Direccion;
                    distri.Correo = oModel.Correo;
                    distri.Telefono = oModel.Telefono;

                    db.Entry(distri).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Distribuidora prov = db.Distribuidoras.Find(id);

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
