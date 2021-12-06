using System;
using System.Threading.Tasks;

namespace Common.Web
{
    public class ThemeService
    {
        public string SelectedTheme { get; set; } = "auto";

        public string RenderedTheme { get; private set; }

        public event Func<Task> ChangeEvent;

        public void Change(string theme)
        {
            RenderedTheme = theme;
            ChangeEvent?.Invoke();
        }
    }
}
