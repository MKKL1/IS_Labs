using System.Text;
using System.Text.Json;
using YamlDotNet.Serialization;
namespace csharp_zadanie;

public class ConvertJsonToYaml
{
    public static void Run(string deserializedData, string destinationFileLocation)
    {
        
    }

    public static void ConvertFile(string jsonFileLocation, string destinationFileLocation)
    {
        //Aby to zadziałało konieczne będzie wykorzystanie innej biblioteki do json,
        // ponieważ JsonSerializer zwraca JsonDocument który jest niekompatybilny z YamlDotNet
        // Prawdopodobnie możliwe jest napisanie odpowiedniego adaptera do YamlDotNet, więc tutaj się poddaje
        
        //Lub poprzez wprowadzenie ograniczenia na format json, przez typ generyczny podany przy Deserialize był by zawsze taki sam
        
        //Nie działa
        object? deserialized = JsonSerializer.Deserialize<object>(File.ReadAllText(jsonFileLocation, Encoding.UTF8));
        var yamlSerializer = new SerializerBuilder().JsonCompatible().Build();
        var yamlData = yamlSerializer.Serialize(deserialized);
        File.WriteAllText(destinationFileLocation, yamlData, Encoding.UTF8);
    }
}