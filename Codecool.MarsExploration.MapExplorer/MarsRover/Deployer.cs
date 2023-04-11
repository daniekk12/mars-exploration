using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class Deployer : IDeployer
{
    public Rover Deploy(int id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations)
    {
        return new Rover(id, position, sight, succesfullLocations);
    }
}