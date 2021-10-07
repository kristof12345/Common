using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Common.Web
{
    public abstract class AppChart<T> : ComponentBase
    {
        [Parameter]
        public IEnumerable<T> Data { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public decimal Max { get; set; }

        [Parameter]
        public decimal Min { get; set; } = 0;

        protected string Style { get { return Loaded ? "" : "visibility: hidden;"; } }

        protected bool Loaded { get; set; }

        protected void OnLoad(object args)
        {
            Loaded = true;
            StateHasChanged();
        }
    }
}