using Design_patterns_in_action.Behavioral;

CompositeCommand command = new CompositeCommand();
command.AddCommand(new BlackAndWhiteCommand());
command.AddCommand(new ResizeCommand());
command.Execute();

