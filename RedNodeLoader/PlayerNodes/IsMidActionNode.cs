using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsMidActionNode : SonsNode
{
    [IsArgOut]
    public bool IsMidAction { get; set; }

    public override void Execute()
    {
        IsMidAction = LocalPlayer.FpCharacter.IsInMidAction;
    }
}
