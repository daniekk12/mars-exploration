namespace Codecool.MarsExploration.MapExplorer.Configuration;

public interface IConfigurationValidator
{
    bool Validate(Configuration config);
}