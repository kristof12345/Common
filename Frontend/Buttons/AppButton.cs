using Microsoft.AspNetCore.Components;

namespace Common.Web;

public class AppButton : AppComponent
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Color { get; set; } = Colors.Primary;

    [Parameter]
    public string Type { get; set; } = "button";

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Outlined { get; set; } = false;

    [Parameter]
    public override string Width { get; set; } = "auto";

    [Parameter]
    public override string Height { get; set; } = "36px";

    [Parameter]
    public override Border Padding { get; set; } = new Border("6px", "12px", "4px", "12px");

    protected string ButtonClass { get => Outlined ? "e-outline" : "e-fill"; }

    protected string ColorStyle
    {
        get
        {
            var color = Disabled ? Colors.Grey : Color;
            return Outlined ? $"color: {color}; border-color: {color};" : $"background-color: {color};";
        }
    }
}
