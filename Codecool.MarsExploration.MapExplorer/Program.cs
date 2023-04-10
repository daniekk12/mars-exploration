using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        string mapFile = $@"{WorkDir}\Resources\exploration-0.map";
        Coordinate landingSpot = new Coordinate(6, 6);
        IEnumerable<string> resources = new List<string>() { "minerals","water" };
        IMapLoader mapLoader = new Loader();
        Map map=mapLoader.Load(mapFile);
        IConfigurationValidator configurationValidator = new ConfigurationValidator();
        
        IDeployer deployer = new Deployer();
        if (configurationValidator.Validate(new Configuration.Configuration(mapFile,landingSpot,resources,1000)))
        {
            deployer.Deploy(1, landingSpot, 5, new List<Coordinate>());
        }
        
    }
}
