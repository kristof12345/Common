using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Demo.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

#if IOS
        var safeInsets = On<iOS>().SafeAreaInsets();
        safeInsets.Bottom = -50;
        Padding = safeInsets;
#endif
    }
}
