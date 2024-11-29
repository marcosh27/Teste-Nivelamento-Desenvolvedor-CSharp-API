using Dapper;
using Questao5.Application.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Context;

namespace Questao5.Infrastructure.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DapperContext _context;

        public ContaCorrenteRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<ContaCorrente> GetByIdAsync(string id)
        {
            const string query = "SELECT * FROM contacorrente WHERE idcontacorrente = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ContaCorrente>(query, new { Id = id });
        }
    }
}
