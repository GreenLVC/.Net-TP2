namespace WebServicesBiblioteca.Models.Request
{
    public class SocioRequest
    {
        public int Id { get; set; }
        public string Apellido { get; set; }  

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public bool Habilitado { get; set; }

    }
}
