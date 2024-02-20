using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetRunSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.FpCharacter.SetRunSpeed((float)args[0]);
    }
}
