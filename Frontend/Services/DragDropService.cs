using Common.Application;
using System;
using System.Collections.Generic;

namespace Common.Web
{
    internal class DragDropService
    {
        public ILabeledValue ActiveItem { get; set; }

        public ILabeledValue DragTargetItem { get; set; }

        public IList<ILabeledValue> Items { get; set; }

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