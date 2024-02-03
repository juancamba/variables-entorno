namespace variables_entorno;

public class PositionOptions
{
    public const string Position = "Position";

    public string Title { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;

    public override string ToString()
    {
        return $"PositionOptions[Title={Title}, Name={Name}]";
    }
}