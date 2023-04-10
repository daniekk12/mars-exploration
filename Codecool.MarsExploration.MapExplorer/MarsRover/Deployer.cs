using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class Deployer : IDeployer
{
    public MarsRover Deploy(int id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations)
    {
        return new MarsRover(id, position, sight, succesfullLocations);
    }
}