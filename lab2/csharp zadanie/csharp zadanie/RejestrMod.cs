using System.Text.Json.Serialization;

namespace csharp_zadanie;

public class RejestrMod
{
    [JsonPropertyName("departments")]
    public List<UrzadMod> Departments { get; set; }
}