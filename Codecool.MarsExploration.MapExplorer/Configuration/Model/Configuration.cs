using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public record Configuration(string File,Coordinate LandingSpot, IEnumerable<String> Resources, int TimeOut);