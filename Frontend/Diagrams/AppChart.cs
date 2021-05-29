using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Common.Web
{
    public abstract class AppChart<T> : ComponentBase
    {
        [Parameter]
        public IEnumerable<T> Data { get; set; }

        protected string Style { get { return Loaded ? "" : "visibility: hidden;"; } }

        protected bool Loaded { get; set; }

        protected void OnLoad()
        {
            Loaded = true;
            StateHasChanged();
        }
    }
}