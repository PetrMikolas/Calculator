using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Calculator.Services.Database;

/// <summary>
/// Service for interacting with the database.
/// </summary>
/// <param name="logger">The logger.</param>
/// <param name="config">The configuration.</param>
public sealed class DatabaseService(ILogger<DatabaseService> logger, IConfiguration config) : IDatabaseService
{
    /// <summary>
    /// Saves an example to the database asynchronously.
    /// </summary>
    /// <param name="example">The example to save.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SaveExampleAsync(string example)
    {
        try
        {
            using var connection = CreateSqlConnection();
            DynamicParameters parameters = new();
            parameters.Add("Example", example);

            await connection.ExecuteAsync("dbo.AddExample", parameters, commandType: CommandType.StoredProcedure);
            logger.LogInformation($"Example {example} saved to the database");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }

    /// <summary>
    /// Retrieves examples from the database asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a list of examples.</returns>
    public async Task<List<string>> GetExamplesAsync()
    {
        try
        {
            using var connection = CreateSqlConnection();
            var examples = (await connection.QueryAsync<string>("dbo.GetExamples", commandType: CommandType.StoredProcedure)).ToList();
            logger.LogInformation("List of examples loaded from the database");
            return examples;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }

    /// <summary>
    /// Creates a new SqlConnection.
    /// </summary>
    /// <returns>The SqlConnection object.</returns>
    private SqlConnection CreateSqlConnection()
    {
        try
        {
            var connectionString = config.GetConnectionString("ExamplesDB") ?? throw new Exception($"Unable to load database connection");
            return new SqlConnection(connectionString);            
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            throw;
        }
    }
}