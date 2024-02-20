using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GetWalkSpeedNode : SonsNode
{
    [IsArgOut]
    public float Speed { get; set; }

    public override void Execute()
    {
        Speed = LocalPlayer.FpCharacter.WalkSpeed;
    }
}
