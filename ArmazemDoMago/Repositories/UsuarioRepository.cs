using ArmazemDoMago.Data;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ArmazemDoMagoDbContext _dbContext;
        public UsuarioRepository(ArmazemDoMagoDbContext armazemDoMagoDbContext)
        { 
            _dbContext = armazemDoMagoDbContext;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
