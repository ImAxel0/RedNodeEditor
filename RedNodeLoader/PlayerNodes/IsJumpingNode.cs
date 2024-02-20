using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsJumpingNode : SonsNode
{
    [IsArgOut]
    public bool IsJumping { get; set; }

    public override void Execute()
    {
        IsJumping = LocalPlayer.FpCharacter.IsJumping;
    }
}
