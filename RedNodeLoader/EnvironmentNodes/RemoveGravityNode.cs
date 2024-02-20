using TheForest.Utils;

namespace RedNodeLoader.EnvironmentNodes;

public class RemoveGravityNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.FpCharacter.SetDisabledGravity((bool)args[0]);
    }
}
