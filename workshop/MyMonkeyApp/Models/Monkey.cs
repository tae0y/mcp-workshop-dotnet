namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey with its characteristics and habitat information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary habitat where the monkey lives.
    /// </summary>
    public string Habitat { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of this monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets additional details about the monkey species.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the conservation status of the monkey species.
    /// </summary>
    public string ConservationStatus { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the monkey with its key information.
    /// </summary>
    /// <returns>A formatted string containing monkey information.</returns>
    public override string ToString()
    {
        return $"{Name} - {Habitat} (Population: {Population:N0}, Status: {ConservationStatus})";
    }
}