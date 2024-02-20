using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsCrouchedNode : SonsNode
{
    [IsArgOut]
    public bool IsCrouched { get; set; }

    public override void Execute()
    {
        IsCrouched = LocalPlayer.FpCharacter.IsCrouchActive;
    }
}
