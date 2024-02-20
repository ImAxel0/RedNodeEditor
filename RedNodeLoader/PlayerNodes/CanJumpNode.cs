using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class CanJumpNode : SonsNode
{
    [IsArgOut]
    public bool CanJump { get; set; }

    public override void Execute()
    {
        CanJump = LocalPlayer.FpCharacter.CanJump;
    }
}
