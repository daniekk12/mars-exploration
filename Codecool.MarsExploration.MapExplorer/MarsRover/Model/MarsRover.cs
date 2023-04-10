using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record MarsRover(string id, Coordinate position, int sight, IEnumerable<Coordinate> succesfullLocations);