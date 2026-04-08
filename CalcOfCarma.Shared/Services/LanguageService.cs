using System.Net.Http.Json;

namespace CalcOfCarma.Shared.Services;

public class LanguageService
{
    private readonly HttpClient _http;
    private Dictionary<string, string> _translations = new();
    
    public string CurrentLanguage { get; private set; } = "uk";
    
    public event Action OnLanguageChanged;

    public LanguageService(HttpClient http)
    {
        _http = http;
    }

    public async Task SetLanguage(string lang)
    {
        if (CurrentLanguage == lang && _translations.Any()) return;

        try
        {
            var path = $"_content/CalcOfCarma.Shared/i18n/{lang.ToLower()}.json";
            var data = await _http.GetFromJsonAsync<Dictionary<string, string>>(path);
            
            if (data != null)
            {
                _translations = data;
                CurrentLanguage = lang;
                OnLanguageChanged?.Invoke();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading language {lang}: {ex.Message}");
        }
    }

    public string this[string key] => _translations.GetValueOrDefault(key, $"[{key}]");
}