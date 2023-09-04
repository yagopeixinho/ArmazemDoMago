using ArmazemDoMago.Data;
using ArmazemDoMago.DTOs;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Repositories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly ArmazemDoMagoDbContext _context;

        public AutenticacaoRepository(ArmazemDoMagoDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<UsuarioModel> ValidarCredenciaisAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = await _context.Usuarios
                 .FirstOrDefaultAsync(u => u.Email == usuarioDTO.Email) 
                 ?? throw new Exception("Email ou senha inválido(s)");
            
            return usuario;
        }
    }
}
