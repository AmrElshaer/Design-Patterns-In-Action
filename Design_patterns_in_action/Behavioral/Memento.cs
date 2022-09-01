namespace Design_patterns_in_action.Behavioral
{
    // Apply undo mechanism
    public class EditorState
    {
        public EditorState(string content)
        {
            Content = content;
        }

        public string Content { get; init; }

    }
    public class Editor
    {
        public string Content { get; private set; }

        public void EditContent(string content)
        {
            this.Content = content;
        }
        public EditorState CreatEditorState()
        {
            return new EditorState(Content);
        }

        public void RestoreState(EditorState state)
        {
            this.Content = state.Content;
        }
    }

    public class History
    {
        private readonly Stack<EditorState> states = new Stack<EditorState>();

        public void AddState(EditorState state)
        {
            states.Push(state);
        }

        public EditorState RemoveState()
        {
            return states.Pop();
        }
    }
}
