using Design_patterns_in_action.Behavioral;

DataSource data = new DataSource();
var spreadSheet = new SpreadSheet(data);
data.Add(spreadSheet);
data.Add(new Chart(data));
data.SetA(5);
data.SetB(5);
data.SetA(6);
data.SetB(8);
Console.WriteLine(spreadSheet.Get());