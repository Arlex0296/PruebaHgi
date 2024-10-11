using System.Collections.Generic;
using pruebaEdwin.Models;

namespace pruebaEdwin.Repositories
{
      
    public interface IUsuariosRepository
    {
        List<Usuario> GetAllUsers();
        Usuario GetUserById(int id);
        void AddUser(Usuario user);
        void UpdateUser(Usuario user);
        void DeleteUser(int id);
        Usuario GetUserByDocument(string document);
    }
}