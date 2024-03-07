using System.Text;
using System.Text.Json;

namespace csharp_zadanie;

public class DeserializeJson
{
    public List<Urzad> RejestUrzedow { get; set; }

    private DeserializeJson(string data)
    {
        RejestUrzedow = JsonSerializer.Deserialize<List<Urzad>>(data);
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
        int stat = RejestUrzedow.Count(urzad =>
            urzad.TypJST == "GM" && urzad.Wojewodztwo == "dolnośląskie");
        Console.WriteLine("liczba urzędów miejskich w województwie dolnośląskim: " + stat);
    }
    
    public void countWoj()
    {
        Dictionary<string, int> wojCount = new();
        foreach (var dep in RejestUrzedow)
        {
            string woj = dep.Wojewodztwo;
            if (wojCount.ContainsKey(woj))
                wojCount[woj]++;
            else wojCount[woj] = 0;

        }

        string result = JsonSerializer.Serialize(wojCount);
        Console.WriteLine(result);
    }
}
    
    