using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Movement;
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
        List<Coordinate> adjacentCoordinates = _coordinateCalculator
            .GetAdjacentCoordinates(_config.LandingSpot,map.Representation.GetLength(0),1)
            .ToList();
        foreach (Coordinate adjacentCoordinate in adjacentCoordinates)
        {
            if (map.Representation[adjacentCoordinate.X,adjacentCoordinate.Y] == " ")
            {
                Coordinate position = new Coordinate(adjacentCoordinate.X, adjacentCoordinate.Y);
                _rover =_deployer.Deploy(1,position,10,new List<Coordinate>());
                map.Representation[position.X, position.Y] = "$";
                break;
            }
        }
        var move = new MovementClass(map);
        while (steps<= _config.TimeOut)
        {
            Console.WriteLine($"X={_rover.position.X} Y={_rover.position.Y}");
            var scanner = new Scanner.Scanner(map);
            Coordinate target = scanner.Scan(_rover,_config.Resources);
            if (target == null)
            {
                var adjCoord = _coordinateCalculator
                    .GetAdjacentCoordinates(_rover.position, map.Representation.GetLength(0))
                    .Where(c=>map.Representation[c.X,c.Y] != "#"||map.Representation[c.X,c.Y] != "#")
                    .ToList();
                target=adjCoord[new Random().Next(0,adjCoord.Count)];
            }
            move.Move(_rover,target);
            Console.WriteLine(map);
            Thread.Sleep(1000);
            Console.Clear();
            steps++;
        }

        return ExplorationOutcome.Timeout;
    }
}