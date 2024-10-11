using Microsoft.AspNetCore.Mvc;
using pruebaEdwin.Models;
using pruebaEdwin.Repositories;
using System.Text.RegularExpressions;


namespace pruebaEdwin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        
        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository; 
        }
         
        // consulta usuarios
         
        // GET: api/usuarios
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usuariosRepository.GetAllUsers();
            return Ok(users);
        }


        // consulta por id 
        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _usuariosRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        /// guarda usuarios
        // POST: api/usuarios
        [HttpPost]
        public IActionResult AddUser([FromBody] Usuario user)
        {
            try
            {
                var nombrePatron = new Regex(@"^.{3,}$");
                var emailPatron = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");

                if (string.IsNullOrWhiteSpace(user.Name) || !nombrePatron.IsMatch(user.Name.Trim()))
                {
                    return BadRequest(new { message = "El nombre del usuario no puede estar vacío y debe tener al menos 3 caracteres." });
                }

                if (string.IsNullOrWhiteSpace(user.Email) || !emailPatron.IsMatch(user.Email.Trim()))
                {
                    return BadRequest(new { message = "El email del usuario debe ser válido (contener un '@' y un '.' en el dominio)." });
                }

                var existeUsuario = _usuariosRepository.GetUserByDocument(user.Document);
                if (existeUsuario != null)
                {
                    return Conflict(new { message = "El documento ya está en uso por otro usuario." });
                }

                _usuariosRepository.AddUser(user);

             
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, new
                {
                    user = user,
                    message = "Usuario creado exitosamente."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new { message = "Error interno del servidor. Por favor, inténtelo más tarde." });
            }
        }




        // actualizar  cambios
        [HttpPut("{id}")] 
        public IActionResult UpdateUser(int id, [FromBody] Usuario user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest("Usuario no válido.");
            }

            try
            {
                // Llama al método sin asignar a una variable
                _usuariosRepository.UpdateUser(user);
                return Ok("Usuario actualizado correctamente."); // Mensaje de éxito
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Usuario no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }







        // eliminar usuario 
        // api/usuarios/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _usuariosRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _usuariosRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
