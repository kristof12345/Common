namespace Common.Web
{
    public class Border
    {
        public string Top { get; set; } = "0px";

        public string Right { get; set; } = "0px";

        public string Bottom { get; set; } = "0px";

        public string Left { get; set; } = "0px";

        public Border() { }

        public Border(string border)
        {
            Top = border;
            Right = border;
            Bottom = border;
            Left = border;
        }

        public Border(string x, string y)
        {
            Top = y;
            Right = x;
            Bottom = y;
            Left = x;
        }

        public Border(string top, string right, string bottom, string left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public static Border FromTop(string border)
        {
            return new Border(border, "0px", "0px", "0px");
        }

        public static Border FromBottom(string border)
        {
            return new Border("0px", "0px", border, "0px");
        }

        public static Border FromLeft(string border)
        {
            return new Border("0px", "0px", "0px", border);
        }

        public static Border FromRight(string border)
        {
            return new Border("0px", border, "0px", "0px");
        }

        public override string ToString()
        {
            return Top + " " + Right + " " + Bottom + " " + Left;
        }
    }
}
