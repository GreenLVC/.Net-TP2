using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesBiblioteca.Models.Response;
using WebServicesBiblioteca.Models;
using WebServicesBiblioteca.Models.Request;

namespace WebServicesBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemplaresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            EjemplaresRespuesta oRespuesta = new EjemplaresRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    var lst = db.Ejemplares.ToList();
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
        public IActionResult Add(EjemplarRequest model)
        {
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Ejemplare oEjemplar = new Ejemplare();
                    oEjemplar.IdLibro = model.IdLibro;
                    db.Ejemplares.Add(oEjemplar);
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
        public IActionResult Edit(EjemplarRequest model)
        {
            SocioRespuesta oRespuesta = new SocioRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Ejemplare oEjemplar = db.Ejemplares.Find(model.IdEjemplar);
                    oEjemplar.IdLibro = model.IdLibro;
                    db.Entry(oEjemplar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Ejemplare oEjemplar = db.Ejemplares.Find(Id);
                    db.Remove(oEjemplar);
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
