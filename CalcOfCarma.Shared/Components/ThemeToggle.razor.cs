using Microsoft.AspNetCore.Components;

namespace CalcOfCarma.Shared.Components;

public partial class ThemeToggle : ComponentBase
{
    [CascadingParameter] public ThemeProvider Theme { get; set; }
    private async Task ToggleTheme()
    {
        if (Theme != null)
        {
            await Theme.ToggleTheme();
        }
    }
}
