using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicesBiblioteca.Models.Response;
using WebServicesBiblioteca.Models;
using WebServicesBiblioteca.Models.Request;

namespace WebServicesBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            LibroRespuesta oRespuesta = new LibroRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    var lst = db.Libros.ToList();
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
        public IActionResult Add(LibroRequest model)
        {
            LibroRespuesta oRespuesta = new LibroRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Libro oLibro = new Libro();
                    oLibro.Titulo = model.Titulo;
                    oLibro.Isbn = model.Isbn;
                    oLibro.NroEdicion = model.NroEdicion;
                    oLibro.FechaEdicion= model.FechaEdicion;
                    oLibro.CantDiasMaxPrestamo = model.CantDiasMaxPrestamo;
                    db.Libros.Add(oLibro);
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
        public IActionResult Edit(LibroRequest model)
        {
            LibroRespuesta oRespuesta = new LibroRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Libro oLibro = db.Libros.Find(model.IdLibro);
                    oLibro.Titulo = model.Titulo;
                    oLibro.Isbn = model.Isbn;
                    oLibro.NroEdicion = model.NroEdicion;
                    oLibro.FechaEdicion = model.FechaEdicion;
                    oLibro.CantDiasMaxPrestamo = model.CantDiasMaxPrestamo;
                    db.Entry(oLibro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            LibroRespuesta oRespuesta = new LibroRespuesta();
            try
            {
                using (bibliotecaContext db = new bibliotecaContext())
                {
                    Libro oLibro = db.Libros.Find(Id);
                    db.Remove(oLibro);
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
