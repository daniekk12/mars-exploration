using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public record Config(string File,Coordinate LandingSpot, IEnumerable<String> Resources, int TimeOut);