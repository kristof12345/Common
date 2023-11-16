using System.Collections.Generic;

namespace Common.Web;

public static class Colors
{
    public const string Primary = "#0071BC";
    public const string Secondary = "#0E308E";
    public const string Tertiary = "#00B0C3";
    public const string Error = "#AD1A24";
    public const string Warning = "#FF9800";
    public const string Success = "#008000";
    public const string Black = "#000000";
    public const string White = "#FFFFFF";
    public const string Grey = "#808080";
    public const string LightGrey = "#424242";
    public const string DarkGrey = "#212121";
    public const string Transparent = "transparent";
    public const string Frame = "#888888";
    public const string Quote = "#FFFF00";

    public const string Worst = "#EA501A";
    public const string Bad = "#F79C02";
    public const string Normal = "#E5CE20";
    public const string Good = "#A1CB43";
    public const string Best = "#82B944";

    public static string Get(int key) { return palettes[key % 10]; }
    private static readonly List<string> palettes = new List<string> { "#0d47a1", "#00838f", "#00b0ff", "#4caf50", "#ff9800", "#dd2c00", "#c51162", "#4527a0", "#880e4f", "#3e2723" };
}
