namespace Codecool.MarsExploration.MapExplorer.Logger;

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        File.ReadAllText(message);
    }
}