using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using System;
using System.Collections.Generic;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Generator;

public class MapElementsGenerator : IMapElementsGenerator
{
    private readonly IMapElementBuilder _builder;

    public MapElementsGenerator(IMapElementBuilder builder)
    {
        _builder = builder;
    }

    public IEnumerable<MapElement> CreateAll(MapConfiguration mapConfig)
    {
        List<MapElement> mapElements = new List<MapElement>();
        foreach (var element in mapConfig.MapElementConfigurations)
        {
            foreach (var (elementCount, dimension) in element.ElementsToDimensions)
            {
                int size = (dimension - element.DimensionGrowth) * (dimension - element.DimensionGrowth);
                for (int i = 0; i <= elementCount; i++)
                {
                    mapElements.Add(_builder.Build(size, element.Symbol, element.Name, element.DimensionGrowth,
                        element.PreferredLocationSymbol));
                }
            }
        }

        return mapElements;
    }
}