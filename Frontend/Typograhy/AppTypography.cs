﻿using Microsoft.AspNetCore.Components;

namespace Common.Web;

public class AppTypography : ComponentBase
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Align { get; set; } = TextAlignment.Center;

    [Parameter]
    public string Width { get; set; } = "auto";

    [Parameter]
    public string Color { get; set; } = "default";

    [Parameter]
    public Border Margin { get; set; } = new Border("0px");

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }
}