using System.Collections.Generic;
using System.Linq;
using pruebaEdwin.Data;
using pruebaEdwin.Models;

namespace pruebaEdwin.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly UserDbContext _context;

        public UsuarioRepository(UserDbContext context)
        {
            _context = context;
        }



           // consulto todos

        public List<Usuario> GetAllUsers()
        {
            return _context.Usuarios.ToList();
        }


        // consulta por id 

        public Usuario GetUserById(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        //  agrego usuario

        public void AddUser(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }



        // actualizo tabla 
        public void UpdateUser(Usuario user)
        {
            var existingUser = _context.Usuarios.Find(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Telefono = user.Telefono;
            existingUser.Edad = user.Edad;
            existingUser.Direccion = user.Direccion;
            existingUser.Document = user.Document;

            _context.SaveChanges();
        }


        // elimino por id

        public void DeleteUser(int id)
          {
            var user = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
            }
          }


           // consulto por docu para verificar  si ya esta  guardado
        public Usuario GetUserByDocument(string document) 
        {
            return _context.Usuarios.FirstOrDefault(u => u.Document == document);
        }
    }
}
