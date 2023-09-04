using ArmazemDoMago.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArmazemDoMago.Repositories.Interfaces
{
    public interface IArmazemRepository
    {
        Task<List<ArmazemModel>> BuscarTodosItems();
        Task<ArmazemModel> BuscarPorId(int id);
        Task<string> AlertaUnidadeItems();
        Task<ArmazemModel> Adicionar(ArmazemModel armazem);
        Task<ArmazemModel> Atualizar(ArmazemModel armazem, int id);
        Task<bool> Apagar(int id);
    }
}
