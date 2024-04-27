using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public class MapElementBuilder : IMapElementBuilder
{
    private IDimensionCalculator dimensionCalculator = new DimensionCalculator();
    public MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null)
    {
        int dimension = dimensionCalculator.CalculateDimension(size, dimensionGrowth);
        string[,] representation = new string[dimension, dimension];
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                representation[i,j] = symbol;
            }
            
        }
        return new MapElement(representation,name,dimension,preferredLocationSymbol);
    }
}