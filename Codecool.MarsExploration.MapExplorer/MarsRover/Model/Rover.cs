using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class Rover
{
    public int id;
    public Coordinate position;
    public int sight;
    public IEnumerable<Coordinate> succesfullLocations;

    public Rover(int id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations)
    {
        this.id=id;
        this.position = position;
        this.sight = sight;
        this.succesfullLocations = succesfullLocations ;
    }
};

