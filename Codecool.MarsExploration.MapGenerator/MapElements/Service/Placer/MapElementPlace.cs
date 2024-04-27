using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlace : IMapElementPlacer
{
    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        bool Bool = false;

        for (int i = 0; i < element.Dimension; i++)
        {
            for (int j = 0; j < element.Dimension; j++)
            {
                if (map[coordinate.X + i, coordinate.Y + j] == null)
                {
                    Bool = true;
                }
                else
                {
                    Bool = false;
                }

                if (map[coordinate.X - i, coordinate.Y - j] == null)
                {
                    Bool = true;
                }
                else
                {
                    Bool = false;
                }
            }
        }

        return Bool;
    }

    public void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        if (CanPlaceElement(element,map,coordinate))
        {
            for (int i = 0; i < element.Dimension/2; i++)
            {
                for (int j = 0; j < element.Dimension/2; j++)
                {
                    map[coordinate.X + i, coordinate.Y + j] = element.Representation[i,j];
                }
            }
            
            for (int i = 0; i < element.Dimension/2; i++)
            {
                for (int j = 0; j < element.Dimension/2; j++)
                {
                    map[coordinate.X - i, coordinate.Y - j] = element.Representation[i,j];
                }
            }
        }
    }
}