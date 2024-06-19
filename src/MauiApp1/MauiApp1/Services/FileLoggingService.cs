using Serilog;

namespace MauiApp1.Services;

internal class FileLoggingService
{
    public const string LogTag = "SecretAligner";
    private const string LogTemplateFilename = "log.txt";

    private const string LogFolderName = "logs";

    private static string LogFolderPath => Path.Combine(FileSystem.AppDataDirectory, LogFolderName);

    internal FileLoggingService()
    {
        var logFilePath = Path.Combine(LogFolderPath, LogTemplateFilename);

        Log.Logger = new LoggerConfiguration()
            .Enrich.WithProperty(Serilog.Core.Constants.SourceContextPropertyName, LogTag)
            .CreateLogger();

        LogInfo($"{nameof(FileLoggingService)} init; path: {logFilePath}");
    }

    internal void LogInfo(string message)
    {
        Log.Information(message);
    }

    internal void LogWarning(string message)
    {
        Log.Warning(message);
    }

    internal void LogError(string message, Exception? ex = null, IDictionary<string, string>? properties = null)
    {
        Log.Error(ex, message, properties);
    }
}
