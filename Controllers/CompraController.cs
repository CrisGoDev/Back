using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCPHARMACY.Models;
using NCPHARMACY.Models.Response;
using NCPHARMACY.Models.Response.Request;
using NCPHARMACY.Services;
using Microsoft.AspNetCore.Authorization;

namespace NCPHARMACY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CompraController : ControllerBase
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
                    var lst = db.Compras.OrderBy(d => d.IdCompra).ToList();
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
        public IActionResult Add(CompraRequest model)
        {
            Respuestas respuesta = new Respuestas();
            try
            {
                var venta = new CompraService();
                venta.Add(model);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }


        [HttpPut]
        public ActionResult Edit(CompraRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdCompra == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }

            try
            {
                var venta = new CompraService();
                venta.Edit(oModel);
                respuesta.Exito = 1;
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
                var venta = new CompraService();
                venta.Delete(id);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
