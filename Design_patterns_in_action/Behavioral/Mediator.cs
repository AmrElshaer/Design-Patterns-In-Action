namespace Design_patterns_in_action.Behavioral
{
    //The Observer pattern: Defines a one-to-many dependency between objects so that
    //when one object changes state, all its dependents are notified and updated automatically.
    //The Mediator pattern: Define an object that encapsulates how a set of objects interact
    // to make loosly coupling between object
    // you can implement mediator using observable
    public abstract class UIControl : Subject
    {

    }

    public class Button : UIControl
    {
        private bool isEnabled;
        public bool IsEnabled() => isEnabled;
        public void SetEnabled(bool isEnabled)
        {
            this.isEnabled = isEnabled;
            Notify();
        }
    }

    public class ListBox : UIControl
    {
        private string selectionContent;
        public string SelectionContent() => selectionContent;
        public void SetContent(string content)
        {
            selectionContent = content;
            Notify();
        }
    }
    public class TextBox : UIControl
    {
        private string content;
        public string SelectionContent() => content;
        public void SetContent(string content)
        {
            this.content = content;
            Notify();
        }
    }

    public class TitleTextChange : Observable
    {
        ArticlesDialogBox articlesDialogBox;

        public TitleTextChange(ArticlesDialogBox articlesDialogBox)
        {
            this.articlesDialogBox = articlesDialogBox;
        }

        public void Update()
        {
            TitleChanged();
        }
        public void TitleChanged()
        {
            var content = articlesDialogBox.textBox.SelectionContent();
            articlesDialogBox.button.SetEnabled(!string.IsNullOrEmpty(content));
        }
    }
    public class ArticleChange : Observable
    {
        readonly ArticlesDialogBox mArticlesDialogBox;
        public ArticleChange(ArticlesDialogBox articlesDialogBox)
        {
            this.mArticlesDialogBox = articlesDialogBox;
        }
        public void Update()
        {
            ArticlesSelected();
        }
        public void ArticlesSelected()
        {
            mArticlesDialogBox.textBox.SetContent(mArticlesDialogBox.articles.SelectionContent());
            mArticlesDialogBox.button.SetEnabled(true);
        }
    }

    // mediator class encapsulate all object
    public class ArticlesDialogBox
    {
        public ListBox articles = new();
        public TextBox textBox = new();
        public Button button = new();

        public ArticlesDialogBox()
        {
            articles.Add(new ArticleChange(this));
            textBox.Add(new TitleTextChange(this));

        }
        public void Simulate()
        {
            articles.SetContent("art 1");
            textBox.SetContent("");
            textBox.SetContent("article 2");
            Console.WriteLine($"Text box {textBox.SelectionContent()}");
            Console.WriteLine($"Button {button.IsEnabled()}");
        }




    }
}
