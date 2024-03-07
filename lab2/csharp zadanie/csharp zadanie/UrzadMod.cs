using System.Text.Json.Serialization;

namespace csharp_zadanie;

public class UrzadMod
{
    [JsonPropertyName("Kod_TERYT")]
    public string? KodTERYT { get; set; }
    [JsonPropertyName("Województwo")]
    public string? Wojewodztwo { get; set; }
    [JsonPropertyName("Powiat")]
    public string? Powiat { get; set; }
    [JsonPropertyName("typ_JST")]
    public string? TypJST { get; set; }
    [JsonPropertyName("nazwa_urzędu_JST")]
    public string? NazwaUrzeduJST { get; set; }
    [JsonPropertyName("miejscowość")]
    public string? Miejscowosc { get; set; }
    [JsonPropertyName("telefon_z_numerem_kierunkowym")]
    public string? TelefonZKierunkowym { get; set; }

    public UrzadMod(Urzad urzad)
    {
        KodTERYT = urzad.KodTERYT;
        Wojewodztwo = urzad.Wojewodztwo;
        Powiat = urzad.Powiat;
        TypJST = urzad.TypJST;
        NazwaUrzeduJST = urzad.NazwaUrzeduJST;
        Miejscowosc = urzad.Miejscowosc;
        TelefonZKierunkowym = urzad.TelefonKierunkowy + urzad.Telefon;
    }
}