using System.Text;
using System.Text.Json;

namespace csharp_zadanie;

public class DeserializeJson
{
    public JsonDocument Data { get; set; }

    private DeserializeJson(string data)
    {
        JsonDocument jsonDocument = JsonDocument.Parse(data);
        Data = jsonDocument;
    }

    public static DeserializeJson create_from_file(string path)
    {
        return new DeserializeJson(File.ReadAllText(path, Encoding.UTF8));
    }

    public static DeserializeJson create_from_data(string data)
    {
        return new DeserializeJson(data);
    }

    public void somestats()
    {
        int example_stat = Data.RootElement
            .EnumerateArray()
            .Count(dep => 
                dep.GetProperty("typ_JST").GetString() == "GM" && 
                dep.GetProperty("Województwo").GetString() == "dolnośląskie");
        Console.WriteLine("liczba urzędów miejskich w województwie dolnośląskim: " + example_stat);
    }
    
    public void countWoj()
    {
        Dictionary<string, int> wojCount = new();
        foreach (var dep in Data.RootElement.EnumerateArray())
        {
            string woj = dep.GetProperty("Województwo").GetString() ?? string.Empty;
            if (wojCount.ContainsKey(woj))
                wojCount[woj]++;
            else wojCount[woj] = 0;

        }

        string result = JsonSerializer.Serialize(wojCount);
        Console.WriteLine(result);
    }
}
    
    