using Microsoft.AspNetCore.Components;

namespace Common.Web
{
    public class AppContainer : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Width { get; set; } = "100%";

        [Parameter]
        public string MaxWidth { get; set; } = "100%";

        [Parameter]
        public string MinWidth { get; set; } = "unset";

        [Parameter]
        public string Height { get; set; } = "auto";

        [Parameter]
        public string MinHeight { get; set; } = "unset";

        [Parameter]
        public Border Padding { get; set; } = new Border("0px");

        [Parameter]
        public Border Margin { get; set; } = new Border("0px");

        [Parameter]
        public string HorizontalAlign { get; set; } = HorizontalAlignment.Center;

        [Parameter]
        public string VerticalAlign { get; set; } = VerticalAlignment.Center;

        [Parameter]
        public string Wrap { get; set; } = FlexWrap.Unset;

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public EventCallback OnClick { get; set; }
    }
}
