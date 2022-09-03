using Design_patterns_in_action.Behavioral;
var document = new HtmlDocument();
document.Add(new AnchorNode());
document.Add(new HeadingNode());
document.Execute(new HighLightOperation());