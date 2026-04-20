using Microsoft.AspNetCore.Components;

namespace CalcOfCarma.Shared.Components;

public partial class Gauge : ComponentBase
{
    [Parameter]
    public double CurrentAngle { get; set; } = 0;
}