﻿using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Generator;
using Codecool.MarsExploration.MapElements.Service.Placer;
using Codecool.MarsExploration.Output.Service;

internal class Program
{
    //You can change this to any directory you like
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        Console.WriteLine("Mars Exploration Sprint 1");
        var mapConfig = GetConfiguration();

        IDimensionCalculator dimensionCalculator = new DimensionCalculator();
        ICoordinateCalculator coordinateCalculator = new CoordinateCalculator();

        IMapElementBuilder mapElementFactory = new MapElementBuilder();
        IMapElementsGenerator mapElementsGenerator = new MapElementsGenerator(mapElementFactory);

        IMapConfigurationValidator mapConfigValidator = new MapConfigurationValidator();
        IMapElementPlacer mapElementPlacer = new MapElementPlace();

        IMapGenerator mapGenerator = new MapGenerator();

        CreateAndWriteMaps(3, mapGenerator, mapConfig);

        Console.WriteLine("Mars maps successfully generated.");
        Console.ReadKey();
    }

    private static void CreateAndWriteMaps(int count, IMapGenerator mapGenerator, MapConfiguration mapConfig)
    {
        for (int i = 0; i < count; i++)
        {
            mapGenerator.Generate(mapConfig);
        }
    }

    private static MapConfiguration GetConfiguration()
    {
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";

        var mountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
        {
            new ElementToDimension(2, 20),
            new ElementToDimension(1, 30),
        }, 3);
        
        var mineralsCfg = new MapElementConfiguration(mineralSymbol, "mineral", new[]
        {
            new ElementToDimension(2, 10),
            new ElementToDimension(1, 15),
        }, 0, "mountain");
        
        var pitsCfg = new MapElementConfiguration(pitSymbol, "pit", new[]
        {
            new ElementToDimension(5, 15),
            new ElementToDimension(3, 25),
        }, 10);
        
        var pocketsOfWaterCfg = new MapElementConfiguration(waterSymbol, "water", new[]
        {
            new ElementToDimension(3, 8),
            new ElementToDimension(1, 12),
        }, 0, "pit");

        List<MapElementConfiguration> elementsCfg = new() { mountainsCfg, mineralsCfg, pitsCfg, pocketsOfWaterCfg };
        return new MapConfiguration(1000, 0.5, elementsCfg);
    }
}
