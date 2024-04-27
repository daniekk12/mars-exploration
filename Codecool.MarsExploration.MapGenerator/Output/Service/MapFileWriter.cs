using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Output.Service;

public class MapFileWriter : IMapFileWriter
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;
    public void WriteMapFile(Map map, string file)
    {
        file = $"{WorkDir}\\Output\\Service";
        
        if (!Directory.Exists(file))
        {
            Directory.CreateDirectory(file);
            Console.WriteLine("Created Directory");
        }

        using (StreamWriter streamWriter = new StreamWriter(file))
        {
            streamWriter.WriteLine(map);
        }
        
    }
}

