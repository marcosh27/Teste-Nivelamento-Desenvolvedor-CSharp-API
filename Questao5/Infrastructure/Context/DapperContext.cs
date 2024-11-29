using System.Data;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Context;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(DatabaseConfig config)
    {
        _connectionString = config.Name ?? throw new ArgumentNullException(nameof(config));
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}