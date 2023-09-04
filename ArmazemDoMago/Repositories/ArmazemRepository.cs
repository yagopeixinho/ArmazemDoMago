using ArmazemDoMago.Data;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Repositories
{
    public class ArmazemRepository : IArmazemRepository
    {
        private readonly ArmazemDoMagoDbContext _context;

        public ArmazemRepository(ArmazemDoMagoDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ArmazemModel>> ListarTodosAsync()
        {
            return await _context.Armazem
                     .OrderByDescending(item => item.PoderMagico)
                     .ToListAsync();
        }

        public async Task<ArmazemModel?> EncontrarPorIdAsync(int id)
        {
           return await _context.Armazem
                      .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ArmazemModel> CriarAsync(ArmazemModel armazem)
        {
            _context.Armazem.Add(armazem);
            await _context.SaveChangesAsync();

            return armazem;
        }

        public async Task<ArmazemModel> AtualizarAsync(ArmazemModel armazem, int id)
        {
            ArmazemModel armazemEncontrado = await EncontrarPorIdAsync(id);

            armazemEncontrado.Nome = armazem.Nome;
            armazemEncontrado.Descricao = armazem.Descricao;
            armazemEncontrado.PoderMagico = armazem.PoderMagico;
            armazemEncontrado.Quantidade = armazem.Quantidade;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return armazemEncontrado;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var armazemEncontrado = await EncontrarPorIdAsync(id);

            if (armazemEncontrado != null)
            {
                _context.Armazem.Remove(armazemEncontrado);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        private static string ConstruirMensagemNotificacao(List<ArmazemModel> itens)
        {
            if (itens.Count == 0)
            {
                return "Seu armazém está cheio... Nenhum item com quantidade inferior a 3 foi encontrado!";
            }

            string singularPlural = itens.Count == 1 ? "do seguinte item" : "dos seguintes itens";
            var mensagem = $"Cuidado, feiticeiro! Seu armazém está com escassez {singularPlural}:\n";

            foreach (var item in itens)
            {
                mensagem += $"ID: {item.Id}, Nome: {item.Nome}, Quantidade: {item.Quantidade}\n";
            }

            return mensagem;
        }

        public async Task<string> NotificacaoBaixoEstoque()
        {
            var itensComQuantidadeInferiorA3 = (await ListarTodosAsync())
                .Where(item => item.Quantidade < 3)
                .ToList();

            return ConstruirMensagemNotificacao(itensComQuantidadeInferiorA3);
        }
    }
}
