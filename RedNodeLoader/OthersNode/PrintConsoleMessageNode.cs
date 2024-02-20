using RedLoader;

namespace RedNodeLoader.OthersNode;

public class PrintConsoleMessageNode : SonsNode
{
    public string Message { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        RLog.Msg((string)args[0]);
    }
}
