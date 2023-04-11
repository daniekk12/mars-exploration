using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulator.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulator;

public class Simulation
{
    private IMapLoader _loader;
    private Rover _rover;
    private IDeployer _deployer;
    private ICoordinateCalculator _coordinateCalculator = new CoordinateCalculator();
    private IConfigurationValidator _configurationValidator;
    private Config _config;

    public Simulation(IMapLoader loader, IDeployer deployer, IConfigurationValidator configurationValidator,Config config)
    {
        _configurationValidator = configurationValidator;
        _deployer = deployer;
        _loader = loader;
        _config = config;
    }
    public ExplorationOutcome Simulate()
    {
        
        if (!_configurationValidator.Validate(_config))
        {
            return ExplorationOutcome.Error;
        }

        int steps = 0;
        Map map = _loader.Load(_config.File);
        List<Coordinate> adjacentCoordinates = _coordinateCalculator.GetAdjacentCoordinates(_config.LandingSpot,0).ToList();
        foreach (Coordinate adjacentCoordinate in adjacentCoordinates)
        {
            if (map.Representation[adjacentCoordinate.X,adjacentCoordinate.Y] == " ")
            {
                _rover = new Rover(1,new Coordinate(adjacentCoordinate.X , adjacentCoordinate.Y),3,new List<Coordinate>());
                break;
            }
            else
            {
                return ExplorationOutcome.Colonizable;
            }
        }

        while (steps<= _config.TimeOut)
        {
            Console.WriteLine(steps);
            steps++;
        }

        return ExplorationOutcome.Timeout;
    }
}