using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Common.Application;

namespace Common.Web
{
    public partial class DropArea : IDisposable
    {
        [Inject]
        private DragDropService DragDropService { get; set; }

        /// <summary>
        /// Allows to pass a delegate which executes if something is dropped and decides if the item is accepted
        /// </summary>
        [Parameter]
        public Func<IUnique, IUnique, bool> Accepts { get; set; }

        /// <summary>
        /// Allows to pass a delegate which executes if something is dropped and decides if the item is accepted
        /// </summary>
        [Parameter]
        public Func<IUnique, bool> AllowsDrag { get; set; }

        /// <summary>
        /// Allows to pass a delegate which executes if a drag operation ends
        /// </summary>
        [Parameter]
        public Action<IUnique> DragEnd { get; set; }

        /// <summary>
        /// Raises a callback with the dropped item as parameter in case the item can not be dropped due to the given Accept Delegate
        /// </summary>
        [Parameter]
        public EventCallback<IUnique> OnItemDropRejected { get; set; }

        /// <summary>
        /// Raises a callback with the replaced item as parameter
        /// </summary>
        [Parameter]
        public EventCallback<IUnique> OnReplacedItemDrop { get; set; }

        /// <summary>
        /// Maximum Number of items which can be dropped in this dropzone. Defaults to null which means unlimited.
        /// </summary>
        [Parameter]
        public int? MaxItems { get; set; }

        /// <summary>
        /// Raises a callback with the dropped item as parameter in case the item can not be dropped due to item limit.
        /// </summary>
        [Parameter]
        public EventCallback<IUnique> OnItemDropRejectedByMaxItemLimit { get; set; }

        /// <summary>
        /// Specifies the id for the Dropzone element.
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Allows to pass a delegate which specifies one or more classnames for the draggable div that wraps your elements.
        /// </summary>
        [Parameter]
        public Func<IUnique, string> ItemWrapperClass { get; set; }

        /// <summary>
        /// If set items dropped are copied to this dropzone and are not removed from their source.
        /// </summary>
        [Parameter]
        public Func<IUnique, IUnique> CopyItem { get; set; }

        private void OnDropItemOnSpacing(int newIndex)
        {
            if (!IsDropAllowed())
            {
                DragDropService.Reset();
                return;
            }

            var activeItem = DragDropService.ActiveItem;
            var oldIndex = Items.IndexOf(activeItem);
            var sameDropZone = false;
            if (oldIndex == -1) // item not present in target dropzone
            {
                if (CopyItem == null)
                {
                    DragDropService.Items.Remove(activeItem);
                }
            }
            else // same dropzone drop
            {
                sameDropZone = true;
                Items.RemoveAt(oldIndex);
                // the actual index could have shifted due to the removal
                if (newIndex > oldIndex)
                    newIndex--;
            }

            if (CopyItem == null)
            {
                Items.Insert(newIndex, activeItem);
            }
            else
            {
                // for the same zone - do not call CopyItem
                Items.Insert(newIndex, sameDropZone ? activeItem : CopyItem(activeItem));
            }

            //Operation is finished
            DragDropService.Reset();
            OnItemDrop.InvokeAsync(activeItem);
        }

        private bool IsMaxItemLimitReached()
        {
            var activeItem = DragDropService.ActiveItem;
            return !Items.Contains(activeItem) && MaxItems.HasValue && MaxItems == Items.Count;
        }

        private string IsItemDragable(IUnique item)
        {
            if (AllowsDrag == null)
                return "true";
            if (item == null)
                return "false";
            return AllowsDrag(item).ToString();
        }

        private bool IsItemAccepted(IUnique dragTargetItem)
        {
            return Accepts == null ? true : Accepts(DragDropService.ActiveItem, dragTargetItem);
        }

        private bool IsValidItem()
        {
            return DragDropService.ActiveItem != null;
        }

        protected override bool ShouldRender()
        {
            return DragDropService.ShouldRender;
        }

        private void ForceRender(object sender, EventArgs e)
        {
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            DragDropService.StateHasChanged += ForceRender;
            base.OnInitialized();
        }

        public string CheckIfDraggable(IUnique item)
        {
            return AllowsDrag == null || item == null || AllowsDrag(item) ? "" : "plk-dd-noselect";
        }

        public string CheckIfDragOperationIsInProgess()
        {
            var activeItem = DragDropService.ActiveItem;
            return activeItem == null ? "" : "plk-dd-inprogess";
        }

        public void OnDragEnd()
        {
            DragEnd?.Invoke(DragDropService.ActiveItem);

            DragDropService.Reset();
        }

        public void OnDragEnter(IUnique item)
        {
            var activeItem = DragDropService.ActiveItem;
            if (item.Equals(activeItem))
                return;
            if (!IsValidItem())
                return;
            if (IsMaxItemLimitReached())
                return;
            if (!IsItemAccepted(item))
                return;
            DragDropService.DragTargetItem = item;

            Swap(DragDropService.DragTargetItem, activeItem);

            DragDropService.ShouldRender = true;
            StateHasChanged();
            DragDropService.ShouldRender = false;
        }

        public void OnDragLeave()
        {
            DragDropService.DragTargetItem = default;
            DragDropService.ShouldRender = true;
            StateHasChanged();
            DragDropService.ShouldRender = false;
        }

        public void OnDragStart(IUnique item)
        {
            DragDropService.ShouldRender = true;
            DragDropService.ActiveItem = item;
            DragDropService.Items = Items;
            StateHasChanged();
            DragDropService.ShouldRender = false;
        }

        public string CheckIfItemIsInTransit(IUnique item)
        {
            return item.Equals(DragDropService.ActiveItem) ? "intransit no-pointer-events" : "";
        }

        public string CheckIfItemIsDragTarget(IUnique item)
        {
            if (item.Equals(DragDropService.ActiveItem))
                return "";
            if (item.Equals(DragDropService.DragTargetItem))
            {
                return IsItemAccepted(DragDropService.DragTargetItem) ? "plk-dd-dragged-over" : "plk-dd-dragged-over-denied";
            }

            return "";
        }

        private string GetClassesForDraggable(IUnique item)
        {
            return ItemWrapperClass != null ? "draggable " + ItemWrapperClass(item) : "draggable";
        }

        private string GetClassesForSpacing(int spacerId)
        {
            return DragDropService.ActiveSpacerId == spacerId && (Items.IndexOf(DragDropService.ActiveItem) == -1 || (spacerId != Items.IndexOf(DragDropService.ActiveItem) && spacerId != Items.IndexOf(DragDropService.ActiveItem) + 1)) ? "spacing spacing-dragged-over" : "spacing";
        }

        private async Task HandleClick(IUnique item)
        {
            await OnClick.InvokeAsync(item);
            await OnItemDrop.InvokeAsync(null);
        }

        private bool IsDropAllowed()
        {
            var activeItem = DragDropService.ActiveItem;
            if (!IsValidItem())
            {
                return false;
            }

            if (IsMaxItemLimitReached())
            {
                OnItemDropRejectedByMaxItemLimit.InvokeAsync(activeItem);
                return false;
            }

            if (!IsItemAccepted(DragDropService.DragTargetItem))
            {
                OnItemDropRejected.InvokeAsync(activeItem);
                return false;
            }

            return true;
        }

        private void OnDrop()
        {
            DragDropService.ShouldRender = true;
            if (!IsDropAllowed())
            {
                DragDropService.Reset();
                return;
            }

            var activeItem = DragDropService.ActiveItem;
            if (DragDropService.DragTargetItem == null) //no direct drag target
            {
                if (!Items.Contains(activeItem)) //if dragged to another dropzone
                {
                    if (CopyItem == null)
                    {
                        Items.Insert(Items.Count, activeItem); //insert item to new zone
                        DragDropService.Items.Remove(activeItem); //remove from old zone
                    }
                    else
                    {
                        Items.Insert(Items.Count, CopyItem(activeItem)); //insert item to new zone
                    }
                }
                else
                {
                    //what to do here?
                }
            }

            DragDropService.Reset();
            StateHasChanged();
            OnItemDrop.InvokeAsync(activeItem);
        }

        private void Swap(IUnique draggedOverItem, IUnique activeItem)
        {
            var indexDraggedOverItem = Items.IndexOf(draggedOverItem);
            var indexActiveItem = Items.IndexOf(activeItem);
            if (indexActiveItem == -1) // item is new to the dropzone
            {
                //insert into new zone
                Items.Insert(indexDraggedOverItem + 1, activeItem);
                //remove from old zone
                DragDropService.Items.Remove(activeItem);
            }
            else
            {
                if (indexDraggedOverItem == indexActiveItem)
                    return;
                (Items[indexActiveItem], Items[indexDraggedOverItem]) = (Items[indexDraggedOverItem], Items[indexActiveItem]);
                OnReplacedItemDrop.InvokeAsync(Items[indexActiveItem]);
            }
        }

        public void Dispose()
        {
            DragDropService.StateHasChanged -= ForceRender;
        }
    }
}