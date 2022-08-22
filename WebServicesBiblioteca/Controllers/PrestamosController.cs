using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesBiblioteca.Models.Response;
using WebServicesBiblioteca.Models;
using WebServicesBiblioteca.Models.Request;

namespace WebServicesBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            PrestamosRespuesta oRespuesta = new PrestamosRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    var lst = db.Prestamos.ToList();
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
        public IActionResult Add(PrestamoRequest model)
        {
            PrestamosRespuesta oRespuesta = new PrestamosRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Prestamo oPrestamo = new Prestamo();
                    oPrestamo.FechaPrestamo = model.FechaPrestamo;
                    oPrestamo.IdSocio = model.IdSocio;
                    db.Prestamos.Add(oPrestamo);
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
        public IActionResult Edit(PrestamoRequest model)
        {
            PrestamosRespuesta oRespuesta = new PrestamosRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Prestamo oPrestamo = db.Prestamos.Find(model.IdPrestamo);
                    oPrestamo.FechaPrestamo = model.FechaPrestamo;
                    oPrestamo.IdSocio = model.IdSocio;
                    db.Prestamos.Add(oPrestamo);
                    db.Entry(oPrestamo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            PrestamosRespuesta oRespuesta = new PrestamosRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Prestamo oPrestamo = db.Prestamos.Find(Id);
                    db.Remove(oPrestamo);
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
