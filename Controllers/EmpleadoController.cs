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
    public class EmpleadoController : ControllerBase
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
                    var lst = db.Empleados.OrderBy(d => d.IdEmpleado).ToList();
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
        public ActionResult Add(EmpleadoRequest oModel)
        {
            Respuestas respuesta = new Respuestas();
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {
                    Empleado empleado = new Empleado();

                    empleado.NombreCompleto = oModel.NombreCompleto;
                    empleado.IdPuestoTrabajo = oModel.IdPuestoTrabajo;
                    empleado.Cedula = oModel.Cedula;
                    empleado.Direccion = oModel.Direccion;
                    empleado.Telefono = oModel.Telefono;
                    empleado.Correo = oModel.Correo;
                    empleado.Estado = oModel.Estado;

                    db.Empleados.Add(empleado);
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
        public ActionResult Edit(Empleado oModel)
        {
            Respuestas respuesta = new Respuestas();
            if (oModel.IdEmpleado == null)
            {
                respuesta.Mensaje = "nulo";
                return Ok(respuesta);
            }
            try
            {
                using (NCPHARMACYContext db = new NCPHARMACYContext())
                {

                    Empleado empleado = db.Empleados.Find(oModel.IdEmpleado);
                    empleado.NombreCompleto = oModel.NombreCompleto;
                    empleado.IdPuestoTrabajo = oModel.IdPuestoTrabajo;
                    empleado.Cedula = oModel.Cedula;
                    empleado.Direccion = oModel.Direccion;
                    empleado.Telefono = oModel.Telefono;
                    empleado.Correo = oModel.Correo;
                    empleado.Estado = oModel.Estado;

                    db.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Empleado prov = db.Empleados.Find(id);

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
