using Codecool.MarsExploration.Calculators.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private readonly Random r = new Random();
    public Coordinate GetRandomCoordinate(int dimension)
    {
        return new Coordinate(r.Next(0, dimension), r.Next(0, dimension));
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension)
    {
        List<Coordinate> coordinates = new List<Coordinate>();
        for (int i = coordinate.X-dimension; i <= coordinate.X+dimension ; i++)
        {
            for (int j = coordinate.Y-dimension; j <= coordinate.Y+dimension ; j++)
            {
                if (j<0)
                {
                    j = 0;
                }
                if (i<0)  
                {
                    i = 0;
                }
                coordinates.Add(new Coordinate(i,j));
            }
        }

        return coordinates;
        
        // VARIANTA INITIALA

        // int plusX = coordinate.X + dimension;
        // int minusX = coordinate.X - dimension;
        // int plusY = coordinate.Y + dimension;
        // int minusY = coordinate.Y - dimension;
        //
        // if (minusX < 0)
        // {
        //     minusX = 0;
        // }
        //
        // if (minusY < 0)
        // {
        //     minusY = 0;
        // }
        //
        // var adjacentCoordinates = new List<Coordinate>
        // {
        //     new (plusX, coordinate.Y),
        //     new (minusX, coordinate.Y),
        //     new (coordinate.X, plusY),
        //     new (coordinate.X, minusY)
        // };
        //
        // return adjacentCoordinates;
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        var adjacentCoordinates = new List<List<Coordinate>>();

        foreach (var coordinate in coordinates)
        {
            adjacentCoordinates.Add(GetAdjacentCoordinates(coordinate, dimension).ToList());
        }

        var flattenedCoordinates = adjacentCoordinates.SelectMany(x => x).ToList();

        return flattenedCoordinates.Distinct();
    }
}