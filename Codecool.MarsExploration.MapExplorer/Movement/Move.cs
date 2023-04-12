using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Microsoft.VisualBasic;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class MovementClass
{
    private Map map;
    private List<Coordinate> visitedCoords;

    public MovementClass(Map map)
    {
        this.map = map;
        visitedCoords = new List<Coordinate>();
    }

    public void Move(Rover rover, Coordinate target)
    {
        // Calculate the distance between the rover position and the target coordinate
        double distance = Math.Sqrt(Math.Pow(target.X - rover.position.X, 2) + Math.Pow(target.Y - rover.position.Y, 2));

        // Define the adjacent coordinates
        var adjacentCoordinates = new CoordinateCalculator()
            .GetAdjacentCoordinates(rover.position, map.Representation.GetLength(0)).ToList();

        // Find the closest adjacent coordinate to the target coordinate
        double minDistance = 9999999999999999;
        int closestX = rover.position.X;
        int closestY = rover.position.Y;
        map.Representation[closestX, closestY] = " ";
        foreach (var adjacentCoordinate in adjacentCoordinates)
        {
            double adjDistance = Math.Sqrt(Math.Pow(target.X - adjacentCoordinate.X, 2) + Math.Pow(target.Y - adjacentCoordinate.Y, 2));
            if (adjDistance < minDistance && IsCoordinateValid(adjacentCoordinate.X, adjacentCoordinate.Y))
            {
                minDistance = adjDistance;
                closestX = adjacentCoordinate.X;
                closestY = adjacentCoordinate.Y;
                Console.WriteLine($"x={closestX}, y={closestY}");
            }
        }
        Console.WriteLine(visitedCoords.Contains(new Coordinate(closestX,closestY)));
        Console.WriteLine(String.Join(",",visitedCoords)+"--------------");
        visitedCoords.Add(new Coordinate(closestX,closestY));
        rover.position = new Coordinate(closestX, closestY);
        map.Representation[closestX, closestY] = "$";
    }

// Check if the coordinate is valid
    private bool IsCoordinateValid(int x, int y)
    {
        return !visitedCoords.Contains(new Coordinate(x,y))&& x >= 0 && x < map.Representation.GetLength(0) && y >= 0 && y < map.Representation.GetLength(0) && (map.Representation[x,y] == " "||map.Representation[x,y] == "*" ||map.Representation[x,y] == "%");
    }

}