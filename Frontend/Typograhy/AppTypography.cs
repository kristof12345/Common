using Microsoft.AspNetCore.Components;

namespace Common.Web
{
    public class AppTypography : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Align { get; set; } = TextAlignment.Center;

        [Parameter]
        public string Color { get; set; }

        [Parameter]
        public Border Margin { get; set; } = new Border("0px");

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Style { get; set; }
    }
}
