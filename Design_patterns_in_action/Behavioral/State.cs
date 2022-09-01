namespace Design_patterns_in_action.Behavioral
{
    // Allows an object to behave differently when it state changes
    public interface Tool
    {
        void MouseDown();
        void MouseUp();
    }
    public class SelectionTool : Tool
    {
        public void MouseDown()
        {
            Console.WriteLine("Selection Icon");
        }

        public void MouseUp()
        {
            Console.WriteLine("Draw dash rectangle");
        }
    }
    public class BrushTool : Tool
    {
        public void MouseDown()
        {
            Console.WriteLine("brush Icon");
        }

        public void MouseUp()
        {
            Console.WriteLine("Draw a line");
        }
    }

    public class Canvas
    {
        private readonly Tool mCurrentTool;

        public Canvas(Tool currentTool)
        {
            this.mCurrentTool = currentTool;
        }

        public void MouseDown()
        {
            mCurrentTool.MouseDown();
        }

        public void MouseUp()
        {
            mCurrentTool.MouseUp();
        }

        public Tool CurrentTool() => mCurrentTool;
    }
}
