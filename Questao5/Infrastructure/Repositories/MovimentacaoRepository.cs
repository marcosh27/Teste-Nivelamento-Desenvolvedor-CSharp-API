using Dapper;
using Questao5.Application.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Context;

namespace Questao5.Infrastructure.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly DapperContext _context;

        public MovimentacaoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task AddMovimentoAsync(Movimentacao movimento)
        {
            const string query = @"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)
                                   VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, movimento);
        }
        public async Task<List<Movimentacao>> GetMovimentosByContaAsync(string idContaCorrente)
        {
            const string query = @"SELECT * FROM movimento WHERE idcontacorrente = @IdContaCorrente";
            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<Movimentacao>(query, new { IdContaCorrente = idContaCorrente })).AsList();
        }
    }
}


