namespace Design_patterns_in_action.Structural
{
    // Bridge pattern is about preferring composition over inheritance.
    // Heroically split it using bridge , if the herocally of inherit is grow solve it using bridge
    //Consider you have a website with different pages and you are supposed to allow the user to change the theme.What would you do? Create multiple copies of each of the pages for each of the themes or would you just create separate theme and load them based on the user's preferences? Bridge pattern allows you to do the second i.e.
    interface IWebPage
    {
        string GetContent();
    }
    interface ITheme
    {
        string GetColor();
    }

    class DarkTheme : ITheme
    {
        public string GetColor()
        {
            return "Dark Black";
        }
    }

    class LightTheme : ITheme
    {
        public string GetColor()
        {
            return "Off White";
        }
    }

    class AquaTheme : ITheme
    {
        public string GetColor()
        {
            return "Light blue";
        }
    }
    class About : IWebPage
    {
        protected ITheme theme;

        public About(ITheme theme)
        {
            this.theme = theme;
        }

        public string GetContent()
        {
            return $"About page in {theme.GetColor()}";
        }
    }

    class Careers : IWebPage
    {
        protected ITheme theme;

        public Careers(ITheme theme)
        {
            this.theme = theme;
        }

        public string GetContent()
        {
            return $"Careers page in {theme.GetColor()}";
        }
    }
}
