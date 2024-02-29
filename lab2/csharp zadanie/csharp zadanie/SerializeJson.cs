using System.Text;
using System.Text.Json;

namespace csharp_zadanie;

public class SerializeJson
{
    public static void runToFile(JsonDocument deserializedData, string path)
    {
        string serialized = JsonSerializer.Serialize(getData(deserializedData));
        File.WriteAllText(path, serialized, Encoding.UTF8);
    }
    
    public static string run(JsonDocument deserializedData)
    {
        return JsonSerializer.Serialize(getData(deserializedData));
    }

    public static JsonDocument getData(JsonDocument data)
    {
        List<Dictionary<string, string>> lst = new();
        string[] etykiety = { "Kod_TERYT", "Województwo", "Powiat", "typ_JST", "nazwa_urzędu_JST", "miejscowość" };
        foreach (var dep in data.RootElement.EnumerateArray())
        {
            Dictionary<string, string> tmpDep = new();
            foreach (var e in etykiety)
            {
                if (dep.TryGetProperty(e, out JsonElement jsonElement))
                {
                    tmpDep[e] = jsonElement.GetString();
                }
            }

            if (dep.TryGetProperty("telefon_kierunkowy", out JsonElement telKierElement) && 
                dep.TryGetProperty("telefon", out JsonElement telElement))
            {
                tmpDep["telefon_z_numerem_kierunkowym"] = telKierElement.GetString() + telElement.GetString();
            }
            
            lst.Add(tmpDep);
        }

        Dictionary<string, List<Dictionary<string, string>>> root = new();
        root["departaments"] = lst;
        return JsonSerializer.SerializeToDocument(lst);
    }
}