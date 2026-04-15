using Microsoft.AspNetCore.Components;

namespace CalcOfCarma.Shared.Components;

public partial class Gauge : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new();
}