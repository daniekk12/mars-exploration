using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Microsoft.VisualBasic;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class MovementClass
{
    private Map map;
    private List<Coordinate> visitedCoords=new();

    public MovementClass(Map map)
    {
        this.map = map;
    }
    public void Move(Rover rover, Coordinate target)
    {
        map.Representation[rover.position.X, rover.position.Y] = " ";
        var adjCoords = new CoordinateCalculator()
            .GetAdjacentCoordinates(new Coordinate(rover.position.X,rover.position.Y),map.Representation.GetLength(0))
            .Where(c=>!visitedCoords.Contains(c)&&(map.Representation[c.X,c.Y]!="#"||map.Representation[c.X,c.Y]!="&"))
            .ToList();
        Console.WriteLine(string.Join(",",adjCoords));
        Coordinate coord=adjCoords[0];
        int xDiff = target.X - rover.position.X;
        int yDiff = target.Y - rover.position.Y;
        if (xDiff != 0)
        {
            int xStep = Math.Sign(xDiff);
            if (map.Representation[rover.position.X + xStep,rover.position.Y]== "#" 
                || map.Representation[rover.position.X + xStep,rover.position.Y]=="&")
            {
                double closestDist=Math.Sqrt(Math.Pow(adjCoords[0].X - target.X, 2) + Math.Pow(adjCoords[0].Y - target.Y, 2));
                foreach (Coordinate adjCoord in adjCoords)
                {
                    double dist = Math.Sqrt(Math.Pow(adjCoord.X - target.X, 2) + Math.Pow(adjCoord.Y - target.Y, 2));
                    if (dist<closestDist)
                    {
                        coord = adjCoord;
                        closestDist = dist;
                    }
                }
                rover.position = new Coordinate(coord.X, rover.position.Y);
            }
            else
            {
                rover.position = new Coordinate(rover.position.X+xStep, rover.position.Y);
            }
            visitedCoords.Add(new Coordinate(rover.position.X, rover.position.Y));
        }
        if (yDiff != 0)
        {
            int yStep = Math.Sign(yDiff);
            if (map.Representation[rover.position.X,rover.position.Y + yStep]== "#" ||
                map.Representation[rover.position.X,rover.position.Y + yStep] == "&")
            {
                double closestDist=Math.Sqrt(Math.Pow(adjCoords[0].X - target.X, 2) + Math.Pow(adjCoords[0].Y - target.Y, 2));
                foreach (Coordinate adjCoord in adjCoords)
                {
                    double dist = Math.Sqrt(Math.Pow(adjCoord.X - target.X, 2) + Math.Pow(adjCoord.Y - target.Y, 2));
                    if (dist < closestDist)
                    {
                        coord = adjCoord;
                        closestDist = dist;
                    }
                }
                Console.WriteLine("am intrat aici");
                rover.position = new Coordinate(rover.position.X, coord.Y);
            }
            else
            {
                rover.position = new Coordinate(rover.position.X, rover.position.Y + yStep);
            }
            visitedCoords.Add(new Coordinate(rover.position.X, rover.position.Y));
        }

        if (yDiff == 0 && xDiff == 0)
        {
            rover.succesfullLocations.Append(target);
            visitedCoords.Add(new Coordinate(rover.position.X, rover.position.Y));
        }
        map.Representation[rover.position.X, rover.position.Y] = "$";
    }

}