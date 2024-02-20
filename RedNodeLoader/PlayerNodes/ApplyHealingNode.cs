using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class ApplyHealingNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.ApplyHealing((float)args[0]);
    }
}
