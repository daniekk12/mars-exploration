using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class MovementClass
{
    private Map map;
    public void Move(Rover rover, Coordinate target)
    {
        int xDiff = target.X - rover.position.X;
        int yDiff = target.Y - rover.position.Y;
        
        if (xDiff != 0)
        {
            int xStep = Math.Sign(xDiff);
            rover.position = new Coordinate(rover.position.X + xStep, rover.position.Y);
        }

        if (yDiff != 0)
        {
            int yStep = Math.Sign(yDiff);
            rover.position = new Coordinate(rover.position.X, rover.position.Y + yStep);
        }
    }

}