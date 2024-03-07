using System.Text;
using System.Text.Json;
using csharp_zadanie;
using YamlDotNet.Serialization;

DeserializeJson deserializeJson = DeserializeJson.create_from_file("Assets\\data.json");
deserializeJson.somestats();
deserializeJson.countWoj();

SerializeJson.runToFile(deserializeJson.RejestUrzedow, "Assets\\data_mod2.json");

ConvertJsonToYaml.ConvertFile("Assets\\data.json", "Assets\\data.yaml");
