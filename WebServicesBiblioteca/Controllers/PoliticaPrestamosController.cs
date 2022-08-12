using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesBiblioteca.Models.Response;
using WebServicesBiblioteca.Models;
using WebServicesBiblioteca.Models.Request;

namespace WebServicesBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticaPrestamosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            PoliticaPrestamoRespuesta oRespuesta = new PoliticaPrestamoRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    var lst = db.PoliticaPrestamos.ToList();
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
        public IActionResult Add(PoliticaPrestamoRequest model)
        {
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    PoliticaPrestamo oPoliticaPrestamo = new PoliticaPrestamo();
                    oPoliticaPrestamo.CantMaxLibrosPend = model.CantMaxLibrosPend;
                    db.PoliticaPrestamos.Add(oPoliticaPrestamo);
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
        public IActionResult Edit(PoliticaPrestamoRequest model)
        {
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    PoliticaPrestamo oPoliticaPrestamo = db.PoliticaPrestamos.Find(model.FechaVigencia);
                    oPoliticaPrestamo.CantMaxLibrosPend = model.CantMaxLibrosPend;
                    db.Entry(oPoliticaPrestamo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PoliticaPrestamo oPoliticaPrestamo = db.PoliticaPrestamos.Find(Id);
                    db.Remove(oPoliticaPrestamo);
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
