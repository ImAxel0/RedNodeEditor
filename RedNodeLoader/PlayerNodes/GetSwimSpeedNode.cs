using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GetSwimSpeedNode : SonsNode
{
    [IsArgOut]
    public float Speed { get; set; }

    public override void Execute()
    {
        Speed = LocalPlayer.FpCharacter.SwimSpeed;
    }
}
