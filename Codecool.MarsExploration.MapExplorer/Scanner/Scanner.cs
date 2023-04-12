using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using System;

namespace Codecool.MarsExploration.MapExplorer.Scanner;

public class Scanner
{
    private Map _map;

    public Scanner(Map map)
    {
        _map = map;
    }
    public Coordinate Scan(Rover rover,IEnumerable<string> resources)
    {
        for (var i = rover.position.X - rover.sight; i <= rover.position.X + rover.sight; i++)
        {
            for (var j = rover.position.Y - rover.sight; j <= rover.position.Y + rover.sight; j++)
            {
                if (i >= 0 && i < _map.Representation.GetLength(0) &&
                    j >= 0 && j < _map.Representation.GetLength(1) &&
                    resources.Contains(_map.Representation[i, j]))
                {
                    return new Coordinate(i, j);
                }
            }
        }
        return null;
    }
}