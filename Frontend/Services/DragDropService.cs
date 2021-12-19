using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Common.Application;

namespace Common.Web
{
    internal class DragDropService
    {
        public IUnique ActiveItem { get; set; }

        public IUnique DragTargetItem { get; set; }

        public IList<IUnique> Items { get; set; }

        public int? ActiveSpacerId { get; set; }

        public void Reset()
        {
            ShouldRender = true;
            ActiveItem = default;
            ActiveSpacerId = null;
            Items = null;
            DragTargetItem = default;

            StateHasChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool ShouldRender { get; set; } = true;

        public EventHandler StateHasChanged { get; set; }
    }
}