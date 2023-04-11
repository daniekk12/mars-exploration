using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulator.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Microsoft.VisualBasic;

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
        List<Coordinate> adjacentCoordinates = _coordinateCalculator.GetAdjacentCoordinates(_config.LandingSpot,map.Representation.GetLength(0),1).ToList();
        Console.WriteLine(string.Join("\n",adjacentCoordinates));
        foreach (Coordinate adjacentCoordinate in adjacentCoordinates)
        {
            Console.WriteLine(map.Representation[adjacentCoordinate.X,adjacentCoordinate.Y]);
            if (map.Representation[adjacentCoordinate.X,adjacentCoordinate.Y] == " ")
            {
                Coordinate position = new Coordinate(adjacentCoordinate.X, adjacentCoordinate.Y);
                _rover =_deployer.Deploy(1,position,3,new List<Coordinate>());
                Console.WriteLine(_rover.position.X);
                break;
            }
        }
        
        while (steps<= _config.TimeOut)
        {
            for (var i = _rover.position.X+_rover.sight; i < _rover.position.X+_rover.sight; i++)
            {
                for (var j = _rover.position.Y+_rover.sight; j < _rover.position.Y+_rover.sight; j++)
                {
                    if (_config.Resources.Contains(map.Representation[i,j]))
                    {Console.WriteLine("salut");
                        while (_rover.position != new Coordinate(i,j))
                        {
                            Console.WriteLine("salut");
                        }
                    }
                    else
                    {
                        int x;
                    }
                }
            }

            steps++;
        }

        return ExplorationOutcome.Timeout;
    }
}