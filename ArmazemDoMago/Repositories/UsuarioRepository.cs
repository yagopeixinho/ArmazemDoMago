using ArmazemDoMago.Data;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ArmazemDoMagoDbContext _context;

        public UsuarioRepository(ArmazemDoMagoDbContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<UsuarioModel>> ListarTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> EncontrarPorIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UsuarioModel> CriarAsync(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return usuario;
        }

        public async Task<UsuarioModel> AtualizarAsync(UsuarioModel usuario, int id)
        {
            var usuarioEncontrado = await EncontrarPorIdAsync(id);


            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Senha = usuario.Senha;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return usuarioEncontrado;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var usuarioEncontrado = await EncontrarPorIdAsync(id);
            if (usuarioEncontrado == null)
            {
                return false; // Indica que o usuário não foi encontrado
            }

            _context.Usuarios.Remove(usuarioEncontrado);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}