using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetRestNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.SetRest((float)args[0]);
    }
}
