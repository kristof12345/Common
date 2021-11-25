namespace Common.Web
{
    public class Border
    {
        private readonly string top;

        private readonly string right;

        private readonly string bottom;

        private readonly string left;

        public Border()
        {
            this.top = "0px";
            this.right = "0px";
            this.bottom = "0px";
            this.left = "0px";
        }

        public Border(string border)
        {
            this.top = border;
            this.right = border;
            this.bottom = border;
            this.left = border;
        }

        public Border(string x, string y)
        {
            this.top = y;
            this.right = x;
            this.bottom = y;
            this.left = x;
        }

        public Border(string top, string right, string bottom, string left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        public static Border From(string border)
        {
            return new Border(border);
        }

        public static Border From(string top, string right, string bottom, string left)
        {
            return new Border(top, right, bottom, left);
        }

        public static Border Top(string border)
        {
            return new Border(border, "0px", "0px", "0px");
        }

        public static Border Bottom(string border)
        {
            return new Border("0px", "0px", border, "0px");
        }

        public static Border Left(string border)
        {
            return new Border("0px", "0px", "0px", border);
        }

        public static Border Right(string border)
        {
            return new Border("0px", border, "0px", "0px");
        }

        public override string ToString()
        {
            return top + " " + right + " " + bottom + " " + left;
        }
    }
}
