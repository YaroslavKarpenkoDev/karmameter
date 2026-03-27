using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CalcOfCarma.Shared.Components;

public partial class ThemeProvider : ComponentBase, IAsyncDisposable
{
    [Inject] private IJSRuntime JS { get; set; } = default;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    public string CurrentTheme { get; private set; } = "light";
    private IJSObjectReference? _module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try 
            {
                _module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/CalcOfCarma.Shared/Components/ThemeProvider.razor.js");

                var savedTheme = await _module.InvokeAsync<string>("getSavedTheme");
            
                if (!string.IsNullOrEmpty(savedTheme))
                {
                    CurrentTheme = savedTheme;
                }
                else
                {
                    CurrentTheme = await _module.InvokeAsync<string>("getSystemTheme");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Theme error: {ex.Message}");
                CurrentTheme = "light"; 
            }

            StateHasChanged();
        }
    }

    public async Task ToggleTheme()
    {
        CurrentTheme = CurrentTheme == "light" ? "dark" : "light";
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("saveTheme", CurrentTheme);
        }
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            await _module.DisposeAsync();
        }
    }
}