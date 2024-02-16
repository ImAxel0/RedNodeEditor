namespace RedNodeEditor.OthersNodes;

public class AddConsoleCommandNode : SonsNode
{
    public string CommandName { get; set; }

    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public AddConsoleCommandNode()
    {
        Name = "AddConsoleCommand";
        Description = "Adds a command to the game debug console (F1) which when executed calls the associated EventName";
        SizeOverride = new(250, 180);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(CommandName) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventId), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
    }
}
