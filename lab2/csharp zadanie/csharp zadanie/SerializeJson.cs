using System.Text;
using System.Text.Json;

namespace csharp_zadanie;

public class SerializeJson
{
    public static void runToFile(List<Urzad> deserializedData, string path)
    {
        string serialized = JsonSerializer.Serialize(getData(deserializedData));
        File.WriteAllText(path, serialized, Encoding.UTF8);
    }
    
    public static string run(List<Urzad> deserializedData)
    {
        return JsonSerializer.Serialize(getData(deserializedData));
    }

    public static JsonDocument getData(IEnumerable<Urzad> data)
    {
        List<UrzadMod> lst = data.Select(dep => new UrzadMod(dep)).ToList();
        RejestrMod rejestrMod = new RejestrMod
        {
            Departments = lst
        };
        return JsonSerializer.SerializeToDocument(rejestrMod);
    }
}