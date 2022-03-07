using System.Collections.Generic;
using Common.Application;
using Microsoft.AspNetCore.Components;

namespace Common.Web
{
    public class AppDiagram : ComponentBase
    {
        [Parameter]
        [EditorRequired]
        public IEnumerable<ILabeledValue> Data { get; set; }

        [Parameter]
        public string Width { get; set; } = "100%";

        [Parameter]
        public string Height { get; set; } = "500px";

        [Parameter]
        public Border Margin { get; set; } = new Border("0px");
    }
}
