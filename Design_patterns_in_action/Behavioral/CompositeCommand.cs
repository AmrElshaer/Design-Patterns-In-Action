namespace Design_patterns_in_action.Behavioral
{
    public interface Command
    {
        void Execute();
    }

    class BlackAndWhiteCommand : Command
    {
        public void Execute()
        {
            Console.WriteLine("Black and white command");
        }
    }

    class ResizeCommand : Command
    {
        public void Execute()
        {
            Console.WriteLine("Resize");
        }
    }

    public class CompositeCommand
    {
        private IList<Command> _commands = new List<Command>();

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }
        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}
