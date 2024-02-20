using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsRunningNode : SonsNode
{
    [IsArgOut]
    public bool IsRunning { get; set; }

    public override void Execute()
    {
        IsRunning = LocalPlayer.FpCharacter.IsRunning;
    }
}
