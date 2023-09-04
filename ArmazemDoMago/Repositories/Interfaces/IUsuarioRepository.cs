using ArmazemDoMago.Models;

namespace ArmazemDoMago.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> ListarTodosAsync();
        Task<UsuarioModel> EncontrarPorIdAsync(int id);
        Task<UsuarioModel> CriarAsync(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarAsync(UsuarioModel usuario, int id);
        Task<bool> ExcluirAsync(int id);
    }
}
