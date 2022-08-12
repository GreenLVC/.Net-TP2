using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesBiblioteca.Models.Response;
using WebServicesBiblioteca.Models;
using WebServicesBiblioteca.Models.Request;

namespace WebServicesBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineasPrestamosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            LineasPrestamosRespuesta oRespuesta = new LineasPrestamosRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    var lst = db.LineasPrestamos.ToList();
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
        public IActionResult Add(LineaPrestamoRequest model)
        {
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    LineasPrestamo oLineasPrestamo = new LineasPrestamo();
                    oLineasPrestamo.FechaDevolucion = model.FechaDevolucion;
                    oLineasPrestamo.Devuelto = model.Devuelto;
                    oLineasPrestamo.IdEjemplar = model.IdEjemplar;
                    oLineasPrestamo.IdPrestamo = model.IdPrestamo;
                    db.LineasPrestamos.Add(oLineasPrestamo);
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
        public IActionResult Edit(LineaPrestamoRequest model)
        {
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    LineasPrestamo oLineasPrestamo = db.LineasPrestamos.Find(model.IdLineaPrestamo);
                    oLineasPrestamo.FechaDevolucion = model.FechaDevolucion;
                    oLineasPrestamo.Devuelto = model.Devuelto;
                    oLineasPrestamo.IdEjemplar = model.IdEjemplar;
                    oLineasPrestamo.IdPrestamo = model.IdPrestamo;
                    db.Entry(oLineasPrestamo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    LineasPrestamo oLineasPrestamo = db.LineasPrestamos.Find(Id);
                    db.Remove(oLineasPrestamo);
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
