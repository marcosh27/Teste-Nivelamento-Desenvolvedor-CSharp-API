using Questao5.Domain.Entities;

namespace Questao5.Application.Interfaces;

public interface IMovimentacaoRepository
{
    Task AddMovimentoAsync(Movimentacao movimento);
    Task<List<Movimentacao>> GetMovimentosByContaAsync(string idContaCorrente);
}