using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public interface IDeployer
{
    public MarsRover Deploy(int id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations);
}