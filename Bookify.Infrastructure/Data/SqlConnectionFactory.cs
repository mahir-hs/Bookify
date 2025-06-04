using System.Data;
using Bookify.Application.Abstractions.Data;

namespace Bookify.Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;
    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }
    public IDbConnection CreateConnection()
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}