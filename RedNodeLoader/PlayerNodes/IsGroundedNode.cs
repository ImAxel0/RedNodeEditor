using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class IsGroundedNode : SonsNode
{
    [IsArgOut]
    public bool IsGrounded {  get; set; }

    public override void Execute()
    {
        IsGrounded = LocalPlayer.FpCharacter.Grounded;
    }
}
