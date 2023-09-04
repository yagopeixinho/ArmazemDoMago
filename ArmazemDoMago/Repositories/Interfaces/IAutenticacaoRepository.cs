using ArmazemDoMago.DTOs;
using ArmazemDoMago.Models;

namespace ArmazemDoMago.Repositories.Interfaces
{
    public interface IAutenticacaoRepository
    {
        Task<UsuarioModel> ValidarCredenciais(UsuarioDTO request);
    }
}
