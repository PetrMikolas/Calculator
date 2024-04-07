namespace Calculator.Services.Database;

/// <summary>
/// Interface for defining database service operations.
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// Saves an example to the database asynchronously.
    /// </summary>
    /// <param name="example">The example to save.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task SaveExampleAsync(string example);

    /// <summary>
    /// Retrieves examples from the database asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a list of examples.</returns>
    public Task<List<string>> GetExamplesAsync();
}