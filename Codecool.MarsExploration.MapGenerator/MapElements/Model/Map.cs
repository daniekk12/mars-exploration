using System.Text;

namespace Codecool.MarsExploration.MapElements.Model;

public record Map(string?[,] Representation, bool SuccessfullyGenerated = false)
{
    protected static string CreateStringRepresentation(string?[,] arr)
    {
        return string.Join("",arr);
    }

    public override string ToString()
    {
        return CreateStringRepresentation(Representation);
    }
}
