using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulator.Model;

public record SimulationContext(int steps,int timeOut, Rover rover, Coordinate spaceshipPosition, Map map, string[] resources, string outcome);