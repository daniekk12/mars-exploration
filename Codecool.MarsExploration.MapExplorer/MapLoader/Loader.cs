using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.MapLoader;

public class Loader : IMapLoader
{
    public Map Load(string mapFile)
    {
        string mapString = File.ReadAllText(mapFile);
        string[] mapStrings = mapString.Split("\n");
        string[,] map = new string[mapStrings.Length, mapStrings[0].Length];

        for (int i = 0; i < mapStrings.Length; i++)
        {
            for (int j = 0; j < mapStrings[i].Length; j++)
            {
                map[i, j] = mapStrings[i][j].ToString();
            }
        }
        return new Map(map, true);
    }
}