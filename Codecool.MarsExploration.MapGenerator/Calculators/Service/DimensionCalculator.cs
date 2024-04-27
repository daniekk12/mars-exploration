namespace Codecool.MarsExploration.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
    public int CalculateDimension(int size, int dimensionGrowth)
    {
        int dimension = (int)Math.Ceiling(Math.Sqrt(size));
        return dimension + dimensionGrowth;
    }
}

// int[,] 2DArray = new int[numberOfRows, numberOfColumns]