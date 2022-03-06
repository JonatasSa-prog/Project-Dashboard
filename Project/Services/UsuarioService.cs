using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public class UsuarioService
    {
        private readonly ProjectContext _context;

        public UsuarioService(ProjectContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public bool GetLogin(string email, string senha)
        {
            return _context.Usuarios.Where(p => p.Email == email && p.Senha == senha).Any();
        }

        public Usuario GetUser(string email, string senha)
        {
            return _context.Usuarios.Where(p => p.Email == email && p.Senha == senha).FirstOrDefault();
        }
    }
}
