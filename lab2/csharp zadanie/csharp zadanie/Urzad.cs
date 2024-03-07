using System.Text.Json.Serialization;

namespace csharp_zadanie;

public class Urzad
{
    [JsonPropertyName("Kod_TERYT")]
    public string? KodTERYT { get; set; }
    [JsonPropertyName("nazwa_samorządu")]
    public string? NazwaSamorzadu { get; set; }
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
    [JsonPropertyName("Kod_pocztowy")]
    public string? KodPocztowy { get; set; }
    [JsonPropertyName("poczta")]
    public string? Poczta { get; set; }
    [JsonPropertyName("Ulica")]
    public string? Ulica { get; set; }
    [JsonPropertyName("Nr_domu")]
    public string? NrDomu { get; set; }
    [JsonPropertyName("telefon_kierunkowy")]
    public string? TelefonKierunkowy { get; set; }
    [JsonPropertyName("telefon")]
    public string? Telefon { get; set; }
    [JsonPropertyName("FAX_kierunkowy")]
    public string? FaxKierunkowy { get; set; }
    [JsonPropertyName("FAX")]
    public string? Fax { get; set; }
    [JsonPropertyName("ogólny_adres_poczty_elektronicznej_gminy_powiatu_województwa")]
    public string? EMail { get; set; }
    [JsonPropertyName("adres_www_jednostki")]
    public string? AdresWWW { get; set; }
    [JsonPropertyName("ESP")]
    public string? ESP { get; set; }
}