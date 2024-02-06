namespace RedNodeEditor.OthersNodes;

public class PrintConsoleMessageNode : SonsNode
{
    public string Message { get; set; }

    public PrintConsoleMessageNode()
    {
        Name = "PrintConsoleMessage";
        Description = "Prints a message on the RedLoader console";

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Message) });
    }
}
