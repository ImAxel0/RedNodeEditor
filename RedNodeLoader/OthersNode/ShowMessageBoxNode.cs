using SonsSdk;

namespace RedNodeLoader.OthersNode;

public class ShowMessageBoxNode : SonsNode
{
    public string Title { get; set; }
    public string Text { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        SonsTools.ShowMessageBox((string)args[0], (string)args[1]);
    }
}
