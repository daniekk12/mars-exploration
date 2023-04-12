using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapGenerator.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private static readonly Random Random = new();

    public Coordinate GetRandomCoordinate(int dimension)
    {
        return new Coordinate(
            Random.Next(dimension),
            Random.Next(dimension)
        );
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension, int reach = 1)
    {
        List<Coordinate> adjacent = new List<Coordinate>();
        for (int i = coordinate.X-reach; i <= coordinate.X+reach; i++)
        {
            for (int j = coordinate.Y-reach; j <= coordinate.Y+reach; j++)
            {
                adjacent.Add(new Coordinate(i,j));
            }
        }
        return adjacent.Where(c => c.X >= 0 && c.Y >= 0 && c.X < dimension && c.Y < dimension&& c!=coordinate);
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        return coordinates.SelectMany(c => GetAdjacentCoordinates(c, dimension));
    }
}
