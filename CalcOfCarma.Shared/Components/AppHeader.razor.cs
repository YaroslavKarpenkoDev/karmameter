using Microsoft.AspNetCore.Components;

namespace CalcOfCarma.Shared.Components;

public partial class AppHeader : ComponentBase
{
    public string CurrentLanguage { get; set; } = "UA";

    protected override void OnInitialized()
    {
        Lang.OnLanguageChanged += StateHasChanged;
    }
    private async Task ToggleLanguage()
    {
        var nextLang = Lang.CurrentLanguage == "uk"  ? "en" : "uk";
        await Lang.SetLanguage(nextLang);
    }

    public void Dispose()
    {
        Lang.OnLanguageChanged -= StateHasChanged;
    }
}