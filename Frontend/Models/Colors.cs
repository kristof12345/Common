using System.Collections.Generic;

namespace Common.Web
{
    public static class Colors
    {
        public static readonly string Primary = "#0071BC";
        public static readonly string Secondary = "#0E308E";
        public static readonly string Tertiary = "#479798";
        public static readonly string Error = "#AD1A24";
        public static readonly string Warning = "#FF9800";
        public static readonly string Success = "#008000";
        public static readonly string Black = "#000000";
        public static readonly string White = "#FFFFFF";
        public static readonly string Grey = "#808080";
        public static readonly string LightGrey = "#424242";
        public static readonly string DarkGrey = "#212121";
        public static readonly string Transparent = "transparent";

        public static string Get(int key) { return palettes[key % 10]; }
        private static readonly List<string> palettes = new List<string> { "#0d47a1", "#00838f", "#00b0ff", "#4caf50", "#ff9800", "#dd2c00", "#c51162", "#4527a0", "#880e4f", "#3e2723" };
    }
}
