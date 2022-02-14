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
    public class InsumoController : ControllerBase
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
                    var lst = db.Insumos.OrderBy(d => d.IdInsumo).ToList();
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
        public ActionResult Add(InsumoRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    Insumo insu = new Insumo();

                    insu.IdInsumo = oModel.IdInsumo;
                    insu.Nombre = oModel.Nombre;
                    insu.IdProveedor = oModel.IdProveedor;
                    insu.Descripcion = oModel.Descripcion;
                    insu.Cantidad = oModel.Cantidad;
                    db.Insumos.Add(insu);
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
        public ActionResult Edit(InsumoRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdInsumo == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    Insumo insu = db.Insumos.Find(oModel.IdInsumo);
                    insu.Nombre = oModel.Nombre;
                    insu.IdProveedor = oModel.IdProveedor;
                    insu.Descripcion = oModel.Descripcion;
                    insu.Cantidad = oModel.Cantidad;
                    db.Entry(insu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Insumo prov = db.Insumos.Find(id);

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

