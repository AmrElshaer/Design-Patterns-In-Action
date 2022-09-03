namespace Design_patterns_in_action.Behavioral
{
    // adding new function to object without modified it
    // instead of modified interface and all concerned 
    // we add new operation to follow Open-closed
    // used when the design stable and operation is change lot
    public interface Operation
    {
        void Apply(HeadingNode headingNode);
        void Apply(AnchorNode anchorNode);
    }

    class HighLightOperation : Operation
    {
        public void Apply(HeadingNode headingNode)
        {
            Console.WriteLine("Hight heading");
        }

        public void Apply(AnchorNode anchorNode)
        {
            Console.WriteLine("high anchor");
        }
    }

    public interface HtmlNode
    {
        void Execute(Operation operation);
    }

    public class HeadingNode : HtmlNode
    {

        public void Execute(Operation operation)
        {
            operation.Apply(this);
        }
    }

    public class AnchorNode : HtmlNode
    {
        public void Execute(Operation operation)
        {
            operation.Apply(this);
        }
    }

    public class HtmlDocument
    {
        private IList<HtmlNode> _nodes = new List<HtmlNode>();

        public void Add(HtmlNode node)
        {
            _nodes.Add(node);
        }

        public void Execute(Operation operation)
        {
            foreach (var htmlNode in _nodes)
            {
                htmlNode.Execute(operation);
            }
        }
    }
}
