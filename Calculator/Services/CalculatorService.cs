using Calculator.Services.Database;
using Calculator.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Calculator.Services;

/// <summary>
/// Service for performing calculator operations.
/// </summary>
/// <param name="logger">The logger.</param>
/// <param name="databaseService">The database service.</param>
public sealed class CalculatorService(ILogger<CalculatorService> logger, IDatabaseService databaseService) : CalculatorGrpc.CalculatorGrpcBase
{

	/// <summary>
	/// Saves an example to the database.
	/// </summary>
	/// <param name="request">The request containing the example to save.</param>
	/// <param name="context">The context of the server-side call.</param>
	/// <returns>An empty response.</returns>
	/// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
	public override async Task<Empty> SaveExample(SaveExampleRequest request, ServerCallContext context)
	{
		logger.LogInformation($"Request to save example: {request}");

		try
		{
			string example = request.Example;

			await databaseService.SaveExampleAsync(example);
			return new Empty();
		}
		catch (Exception ex)
		{
			logger.LogError(ex.ToString());
			throw new Exception($"Error occurred while saving example to the database: {ex.Message}");
		}
	}

	/// <summary>
	/// Retrieves examples from the database.
	/// </summary>
	/// <param name="request">The request for retrieving examples.</param>
	/// <param name="context">The context of the server-side call.</param>
	/// <returns>A response containing a list of examples.</returns>
	/// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
	public override async Task<GetExamplesResponse> GetExamples(Empty request, ServerCallContext context)
	{
		logger.LogInformation("Request to retrieve examples");

		try
		{
			return new GetExamplesResponse()
			{
				Examples = { await databaseService.GetExamplesAsync() },
			};
		}
		catch (Exception ex)
		{
			logger.LogError(ex.ToString());
			throw new Exception($"Error occurred while loading data from the database: {ex.Message}");
		}
	}
}