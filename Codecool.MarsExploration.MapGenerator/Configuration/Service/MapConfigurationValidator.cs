using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
    public bool Validate(MapConfiguration mapConfig)
    {
        int totalElements = 0;
        int totalDimension = 0;
        foreach (var elementConfig in mapConfig.MapElementConfigurations)
        {
            
            foreach (var (elementCount, dimension) in elementConfig.ElementsToDimensions)
            {
                totalElements += elementCount;
                totalDimension += dimension;
            }
        }

        if (totalDimension > mapConfig.MapSize * mapConfig.MapSize * mapConfig.ElementToSpaceRatio)
        {
            return false;
        }
        foreach (var elementConfig in mapConfig.MapElementConfigurations)
        {
            if (elementConfig.Symbol == "%" && elementConfig.ElementsToDimensions.Count() > 1)
            {
                return false;
            }
            
            if (elementConfig.Symbol == "*" && elementConfig.ElementsToDimensions.Count() > 1)
            {
                return false;
            }
        }
        return true;
    }
}