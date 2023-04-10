using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public class ConfigurationValidator : IConfigurationValidator
{
    private ICoordinateCalculator _coordinateCalculator = new CoordinateCalculator();
    private IMapLoader _mapLoader = new Loader();
    public bool Validate(Configuration config)
    {
        Map map = _mapLoader.Load(config.File);
        if (map.Representation[config.LandingSpot.X,config.LandingSpot.Y] != " ")
        {
            return false;
        }

        List<Coordinate> adCoordinates = _coordinateCalculator.GetAdjacentCoordinates(config.LandingSpot, map.Dimension).ToList();
        
        for (var i = 0; i < adCoordinates.Count; i++)
        {
            if (map.Representation[adCoordinates[i].X,adCoordinates[i].Y] == null)
            {
                return true;
            }
        }

        if (map.Representation.ToString() == string.Empty)
        {
            return false;
        }

        if (config.Resources.Count() == 0)
        {
            return false;
        }

        if (config.TimeOut <= 0)
        {
            return false;
        }
        
        return true;
    }
}