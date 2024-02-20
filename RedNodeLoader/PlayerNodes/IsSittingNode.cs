using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsSittingNode : SonsNode
{
    [IsArgOut]
    public bool IsSitting { get; set; }

    public override void Execute()
    {
        IsSitting = LocalPlayer.FpCharacter.Sitting;
    }
}
