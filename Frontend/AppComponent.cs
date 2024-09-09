using Microsoft.AspNetCore.Components;

namespace Common.Web;

public class AppComponent : ComponentBase
{
    [Parameter]
    public string Id { get; set; }

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public virtual string Width { get; set; } = "100%";

    [Parameter]
    public virtual string MaxWidth { get; set; } = "100%";

    [Parameter]
    public virtual string MinWidth { get; set; } = "unset";

    [Parameter]
    public virtual string Height { get; set; } = "auto";

    [Parameter]
    public virtual Border Padding { get; set; } = new Border("0px");

    [Parameter]
    public virtual Border Margin { get; set; } = new Border("0px");

    [Parameter]
    public virtual bool Visible { get; set; } = true;

    protected virtual string Visibility { get => Visible ? "visible" : "hidden"; }

    protected string Css { get => $"width: {Width}; min-width: {MinWidth}; max-width: {MaxWidth}; height: {Height}; padding: {Padding}; margin: {Margin}; visibility: {Visibility}; {Style}"; }
}