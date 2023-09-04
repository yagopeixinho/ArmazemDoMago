using ArmazemDoMago.Data;
using ArmazemDoMago.DTOs;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Repositories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly ArmazemDoMagoDbContext _dbContext;

        public AutenticacaoRepository(ArmazemDoMagoDbContext armazemDoMagoDbContext)
        {
            _dbContext = armazemDoMagoDbContext;
        }
        public async Task<UsuarioModel> ValidarCredenciais(UsuarioDTO request)
        {
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(usuario => usuario.Email == request.Email);

            return usuario == null ? throw new Exception("Email ou senha inválido(s)") : usuario;
        }
    }
}
