namespace MyMonkeyApp.Models;

public class Monkey
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Image { get; set; } = string.Empty;
    public double Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Species}) - {Location}";
    }
}