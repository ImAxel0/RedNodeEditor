using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsConnectedToLogSledNode : SonsNode
{
    [IsArgOut]
    public bool IsConnected { get; set; }

    public override void Execute()
    {
        IsConnected = LocalPlayer.AnimControl.IsConnectedToLogSled();
    }
}
