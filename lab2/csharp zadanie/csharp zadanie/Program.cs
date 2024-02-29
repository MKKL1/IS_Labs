using System.Text;
using System.Text.Json;
using csharp_zadanie;
DeserializeJson deserializeJson = DeserializeJson.create_from_file("Assets\\data.json");
deserializeJson.somestats();
deserializeJson.countWoj();

SerializeJson.runToFile(deserializeJson.Data, "Assets\\data_mod2.json");

