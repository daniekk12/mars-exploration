using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class Movement
{
    private Map map;
    public void Move(Rover rover,Coordinate target)
    {
        if (target.X < rover.position.X)
        {
            rover.position = new Coordinate(rover.position.X + 1, rover.position.Y);
        }
        else
        {
            rover.position = new Coordinate(rover.position.X - 1, rover.position.Y);
        }
        if (target.Y < rover.position.Y)
        {
            rover.position = new Coordinate(rover.position.X, rover.position.Y+1);
        }
        else
        {
            rover.position = new Coordinate(rover.position.X, rover.position.Y-1);
        }
    }
}