namespace Codecool.MarsExploration.MapExplorer.Logger;

public class ConsoleLogger: ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}