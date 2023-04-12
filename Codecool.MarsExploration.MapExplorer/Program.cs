using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulator;
using Codecool.MarsExploration.MapExplorer.Simulator.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";
        
        string mapFile = $@"{WorkDir}\Resources\exploration-0.map";
        string[] resources = { mineralSymbol,waterSymbol};
        
        Coordinate landingSpot = new Coordinate(0, 0);
        IMapLoader mapLoader = new Loader();
        IDeployer deployer = new Deployer();
        IConfigurationValidator configurationValidator = new ConfigurationValidator();

        Config config = new Config(mapFile, landingSpot, resources, 1000);
        Simulation simulation = new Simulation(mapLoader,deployer,configurationValidator,config);
        simulation.Simulate();
    }
}
