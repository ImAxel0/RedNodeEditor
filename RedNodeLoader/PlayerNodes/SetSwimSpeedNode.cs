using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetSwimSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.FpCharacter.SetSwimSpeed((float)args[0]);
    }
}
