using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public record Configuration(string file,Coordinate landingSpot,IEnumerable<String> resources, int timeOut);