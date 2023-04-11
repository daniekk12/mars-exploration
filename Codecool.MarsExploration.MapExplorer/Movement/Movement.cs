using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Movement;

public class Movement
{
    private Map map;
    public Rover Move(Rover rover, string direction)
    {
        Coordinate position = direction switch
        {
            "down" => new Coordinate(rover.position.X, rover.position.Y - 1),
            "up" => new Coordinate(rover.position.X, rover.position.Y + 1),
            "left" => new Coordinate(rover.position.X - 1, rover.position.Y),
            "right" => new Coordinate(rover.position.X + 1, rover.position.Y),
        };
        return new Rover(rover.id, position, rover.sight, rover.succesfullLocations);
    }
}