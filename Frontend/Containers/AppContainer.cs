using Microsoft.AspNetCore.Components;

namespace Common.Web;

public class AppContainer : AppComponent
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string MinHeight { get; set; } = "unset";

    [Parameter]
    public string HorizontalAlign { get; set; } = HorizontalAlignment.Center;

    [Parameter]
    public string VerticalAlign { get; set; } = VerticalAlignment.Center;

    [Parameter]
    public string Wrap { get; set; } = FlexWrap.Unset;

    [Parameter]
    public string Gap { get; set; } = "unset";

    [Parameter]
    public EventCallback OnClick { get; set; }
}

