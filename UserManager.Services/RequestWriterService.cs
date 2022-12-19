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
            _logger.LogInformation("{TargetDirectory} was not found, creating...", targetDirectory);
            Directory.CreateDirectory(targetDirectory);
            _logger.LogInformation("{TargetDirectory} created", targetDirectory);
        }
        var fileName = userRequest.Name?.Replace(" ", "_") ?? Guid.NewGuid().ToString();
        var filePath = Path.Combine(targetDirectory, $"{fileName}.json");
        if (File.Exists(filePath))
        {
            _logger.LogWarning("{FilePath} already exists", filePath);
        }
        _logger.LogInformation("Writing {FilePath}", filePath);
        File.WriteAllText(filePath, JsonSerializer.Serialize(userRequest));
        _logger.LogInformation("{FilePath} written successfully", filePath);
    }
}