using ArmazemDoMago.Models;

namespace ArmazemDoMago.Repositories.Interfaces
{
    public interface IArmazemRepository
    {
        Task<List<ArmazemModel>> ListarTodosAsync();
        Task<ArmazemModel?> EncontrarPorIdAsync(int id);
        Task<ArmazemModel> CriarAsync(ArmazemModel armazem);
        Task<ArmazemModel> AtualizarAsync(ArmazemModel armazem, int id);
        Task<bool> ExcluirAsync(int id);
        Task<string> NotificacaoBaixoEstoque();
    }
}
