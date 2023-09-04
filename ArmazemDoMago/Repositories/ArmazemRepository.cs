using ArmazemDoMago.Data;
using ArmazemDoMago.Models;
using ArmazemDoMago.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Repositories
{
    public class ArmazemRepository : IArmazemRepository
    {
        private readonly ArmazemDoMagoDbContext _dbContext;

        public ArmazemRepository(ArmazemDoMagoDbContext armazemDoMagoDbContext)
        {
            _dbContext = armazemDoMagoDbContext;
        }

        public async Task<ArmazemModel> Adicionar(ArmazemModel armazem)
        {
            await _dbContext.Armazem.AddAsync(armazem);
            await _dbContext.SaveChangesAsync();

            return armazem;
        }

        public async Task<bool> Apagar(int id)
        {
            ArmazemModel armazemPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID: {id} não foi encontrado.");
            _dbContext.Armazem.Remove(armazemPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ArmazemModel> Atualizar(ArmazemModel armazem, int id)
        {
            ArmazemModel armazemPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID: {id} não foi encontrado.");
            
            armazemPorId.Nome = armazem.Nome;
            armazemPorId.Descricao = armazem.Descricao;
            armazemPorId.PoderMagico = armazem.PoderMagico;
            armazemPorId.Quantidade = armazem.Quantidade;

            _dbContext.Armazem.Update(armazemPorId);
            await _dbContext.SaveChangesAsync();

            return armazemPorId;
        }

        public async Task<ArmazemModel> BuscarPorId(int id)
        {
            return await _dbContext.Armazem.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ArmazemModel>> BuscarTodosItems()
        {
            return await _dbContext.Armazem.OrderByDescending(item => item.PoderMagico).ToListAsync();
        }

        public async Task<string> AlertaUnidadeItems()
        {
            var ItensArmazem = await BuscarTodosItems();

            var itensComQuantidadeInferiorA3 = ItensArmazem.Where(item => item.Quantidade < 3).ToList();


            if (itensComQuantidadeInferiorA3.Count == 0)
            {
                return "Seu armazém está cheio... Nenhum item com a quantidade inferior a 3 foi encontrado!";
            }
            else if(itensComQuantidadeInferiorA3.Count == 1)
            {
                // Construa uma string personalizada com os itens faltando
                string mensagem = "Foi encontrado a escazes de 1 item no seu armazém:\n";
                foreach (var item in itensComQuantidadeInferiorA3)
                {
                    mensagem += $"ID: {item.Id}, Nome: {item.Nome}, Quantidade: {item.Quantidade}\n";
                }

                return mensagem;
            } else
            {
                // Construa uma string personalizada com os itens faltando
                string mensagem = "Cuidado, feiticeiro! Seu armazem está com escazes dos seguintes itens:\n";
                foreach (var item in itensComQuantidadeInferiorA3)
                {
                    mensagem += $"ID: {item.Id}, Nome: {item.Nome}, Quantidade: {item.Quantidade}\n";
                }

                return mensagem;
            }
        }
    }
}
