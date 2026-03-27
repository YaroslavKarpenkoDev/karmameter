using Microsoft.AspNetCore.Components;

namespace CalcOfCarma.Shared.Components;

public partial class AppHeader : ComponentBase
{
    public string CurrentLanguage { get; set; } = "UA";

    

    private void ToggleLanguage()
    {
        CurrentLanguage = CurrentLanguage == "UA"  ? "EN" : "UA";
    }
}