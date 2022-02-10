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
            model.CssClass = type switch
            {
                ToastType.Success => "e-toast-success",
                ToastType.Warning => "e-toast-warning",
                ToastType.Danger => "e-toast-danger",
                ToastType.Info => "e-toast-info",
                _ => throw new InvalidOperationException("Unexpected value: " + type),
            };
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