using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record Rover(string id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations);