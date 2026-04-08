using Microsoft.AspNetCore.Components;

namespace CalcOfCarma.Shared.Layout;

public partial class MainLayout : LayoutComponentBase
{
    private bool _isLoaded;

    protected override async Task OnInitializedAsync()
    {
        await Lang.SetLanguage("uk"); // Чекаємо завантаження JSON
        _isLoaded = true;
    }
}
