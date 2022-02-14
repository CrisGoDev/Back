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
    public class DetallesCompraController : ControllerBase
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
                    var lst = db.DetallesCompras.OrderBy(d => d.IdDetalleCompra).ToList();
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
        public ActionResult Add(DetallesCompraRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    DetallesCompra prov = new DetallesCompra();
                    prov.IdDetalleCompra = oModel.IdDetalleCompra;
                    prov.IdCompra = oModel.IdCompra;
                    prov.IdInsumo = oModel.IdInsumo;
                    prov.Cantidad = oModel.Cantidad;
                    prov.Descuento = oModel.Descuento;
                    prov.PrecioUnitario = oModel.PrecioUnitario;
                    db.DetallesCompras.Add(prov);
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
        public ActionResult Edit(DetallesCompraRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdDetalleCompra == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    DetallesCompra prov = db.DetallesCompras.Find(oModel.IdDetalleCompra);

                    prov.IdCompra = oModel.IdCompra;
                    prov.IdInsumo = oModel.IdInsumo;
                    prov.Cantidad = oModel.Cantidad;
                    prov.Descuento = oModel.Descuento;
                    prov.PrecioUnitario = oModel.PrecioUnitario;
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
                    DetallesCompra prov = db.DetallesCompras.Find(id);

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

