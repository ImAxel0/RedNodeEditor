using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetWalkSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.FpCharacter.SetWalkSpeed((float)args[0]);
    }
}
