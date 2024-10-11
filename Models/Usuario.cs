using System.ComponentModel.DataAnnotations;


namespace pruebaEdwin.Models
{

     public class Usuario
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public string Direccion { get; set; }

        [Required] 
        public string Document { get; set; } 

    }
}

