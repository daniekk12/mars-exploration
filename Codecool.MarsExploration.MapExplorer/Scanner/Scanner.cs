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
    public Coordinate Scan(Rover rover, IEnumerable<string> resources)
    {
        List<Coordinate> targetCoords = new List<Coordinate>();
        for (var i = rover.position.X - rover.sight; i <= rover.position.X + rover.sight; i++)
        {
            for (var j = rover.position.Y - rover.sight; j <= rover.position.Y + rover.sight; j++)
            {
                if (i >= 0 && i < _map.Representation.GetLength(0) &&
                    j >= 0 && j < _map.Representation.GetLength(1) &&
                    resources.Contains(_map.Representation[i, j]))
                {
                    targetCoords.Add(new Coordinate(i, j));
                }
            }
        }

        if (targetCoords.Count == 0)
        {
            return null; // No target coordinates found
        }

        Coordinate closestCoord = targetCoords[0];
        double closestDistance = CalculateDistance(rover.position, closestCoord);

        foreach (var coordinate in targetCoords)
        {
            double distance = CalculateDistance(rover.position, coordinate);
            if (distance < closestDistance)
            {
                closestCoord = coordinate;
                closestDistance = distance;
            }
        }

        return closestCoord;
    }

    private double CalculateDistance(Coordinate coord1, Coordinate coord2)
    {
        double deltaX = coord2.X - coord1.X;
        double deltaY = coord2.Y - coord1.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

}