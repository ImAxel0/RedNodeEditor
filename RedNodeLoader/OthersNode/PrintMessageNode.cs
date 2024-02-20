using SonsSdk;

namespace RedNodeLoader.OthersNode;

public class PrintMessageNode : SonsNode
{
    public string Message { get; set; }
    public float Duration { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        SonsTools.ShowMessage((string)args[0], (float)args[1]);
    }
}
