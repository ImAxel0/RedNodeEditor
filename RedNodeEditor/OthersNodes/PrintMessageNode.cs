namespace RedNodeEditor.OthersNodes;

public class PrintMessageNode : SonsNode
{
    public string Message { get; set; }
    public float Duration { get; set; } = 1f;

    public PrintMessageNode()
    {
        Name = "PrintMessage";
        Description = "Prints a message on the bottom left of the screen (like when the player pickup something)";

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Message) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Duration) });
    }
}
