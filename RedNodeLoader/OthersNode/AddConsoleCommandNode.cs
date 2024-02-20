using TheForest;

namespace RedNodeLoader.OthersNode;

public class AddConsoleCommandNode : SonsNode
{
    public string CommandName { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        DebugConsole.RegisterCommand((string)args[0], (Il2CppSystem.Func<string, bool>)RedNodeLoader.GetCustomEvent(EventId).Execute, DebugConsole.Instance);
    }
}
