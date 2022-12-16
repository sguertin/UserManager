using UserManager.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace UserManager.Services;

public class RequestWriterService : IRequestWriterService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<RequestWriterService> _logger;

    public RequestWriterService(IConfiguration configuration, ILogger<RequestWriterService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public void WriteRequest(CreateUserModel userRequest)
    {
        var targetDirectory = _configuration["TargetDirectory"] ?? throw new Exception("No Target Directory specified!");
        if (!Directory.Exists(targetDirectory))
        {
            _logger.LogInformation("{targetDirectory} was not found, creating...", targetDirectory);
            Directory.CreateDirectory(targetDirectory);
            _logger.LogInformation("{targetDirectory} created", targetDirectory);
        }
        var fileName = userRequest.Name?.Replace(" ", "_") ?? Guid.NewGuid().ToString();
        var filePath = Path.Combine(targetDirectory, $"{fileName}.json") ;
        if (File.Exists(filePath))
        {
            _logger.LogInformation("Overwriting {filePath}", filePath);
        }
        else
        {
            _logger.LogInformation("Creating {filePath}", filePath);
        }        
        File.WriteAllText(filePath, JsonSerializer.Serialize(userRequest));
        _logger.LogInformation("{filePath} written successfully", filePath);
    }
}