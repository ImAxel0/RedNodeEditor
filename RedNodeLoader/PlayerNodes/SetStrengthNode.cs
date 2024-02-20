using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetStrengthNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.SetStrength((float)args[0]);
    }
}
