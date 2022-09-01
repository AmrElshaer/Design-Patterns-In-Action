using Design_patterns_in_action.Behavioral;

Editor editor = new();
History history = new History();
editor.EditContent("a");
history.AddState(editor.CreatEditorState());
editor.EditContent("b");
history.AddState(editor.CreatEditorState());
editor.EditContent("c");
editor.RestoreState(history.RemoveState());
Console.WriteLine(editor.Content);

