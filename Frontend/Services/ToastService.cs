using System;
using System.Threading.Tasks;
using Syncfusion.Blazor.Notifications;

namespace Common.Web
{
    public class ToastService
    {
        public SfToast Toaster { get; set; }

        public async Task Add(string content, ToastType type)
        {
            var model = new ToastModel { Content = content };
            switch (type)
            {
                case ToastType.Success: model.CssClass = "e-toast-success"; break;
                case ToastType.Warning: model.CssClass = "e-toast-warning"; break;
                case ToastType.Danger: model.CssClass = "e-toast-danger"; break;
                case ToastType.Info: model.CssClass = "e-toast-info"; break;
                default: throw new InvalidOperationException("Unexpected value: " + type);
            }
            await Toaster.Show(model);
        }
    }

    public enum ToastType
    {
        Success,
        Warning,
        Danger,
        Info
    }
}
