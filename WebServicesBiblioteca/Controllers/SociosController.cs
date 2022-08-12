using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesBiblioteca.Models.Response;
using WebServicesBiblioteca.Models;
using WebServicesBiblioteca.Models.Request;

namespace WebServicesBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    var lst = db.Socios.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        [HttpPost]
        public IActionResult Add(SocioRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Socio oSocio = new Socio();
                    oSocio.Apellido = model.Apellido;
                    oSocio.Nombre = model.Nombre;
                    oSocio.Email = model.Email;
                    oSocio.Telefono = model.Telefono;
                    oSocio.Domicilio = model.Domicilio;
                    oSocio.Habilitado = model.Habilitado;
                    db.Socios.Add(oSocio);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(SocioRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Socio oSocio = db.Socios.Find(model.Id);
                    oSocio.Apellido = model.Apellido;
                    oSocio.Nombre = model.Nombre;
                    oSocio.Email = model.Email;
                    oSocio.Telefono = model.Telefono;
                    oSocio.Domicilio = model.Domicilio;
                    oSocio.Habilitado = model.Habilitado;
                    db.Entry(oSocio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Socio oSocio = db.Socios.Find(Id);
                    db.Remove(oSocio);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
