using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public interface IDeployer
{
    public Rover Deploy(int id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations);
}