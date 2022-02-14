using Microsoft.AspNetCore.Authorization;
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

    //[Authorize]
    public class DetalleLineaDeProduccioneController : ControllerBase
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
                    var lst = db.DetalleLineaDeProducciones.OrderBy(d => d.IdLineaDeProduccion).ToList();
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
        public IActionResult Add(LineaDeProduccioneRequest model)
        {
            Respuestas respuesta = new Respuestas();
            try
            {/*
                var venta = new LineaDeProduccionService();
                venta.Add(model);*/
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut]
        public ActionResult Edit(DetalleLineaDeProduccioneRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdDetalleLineaDeProduccion == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    DetalleLineaDeProduccione prov = db.DetalleLineaDeProducciones.Find(oModel.IdDetalleLineaDeProduccion);

                    prov.IdLineaDeProduccion = oModel.IdLineaDeProduccion;
                    prov.IdInsumo = oModel.IdInsumo;
                    prov.Cantidad = oModel.Cantidad;
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

        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
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
                    DetalleLineaDeProduccione prov = db.DetalleLineaDeProducciones.Find(id);

                    db.Remove(prov);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            respuesta.Mensaje = id;
            return Ok(respuesta);
        }
    }
}
