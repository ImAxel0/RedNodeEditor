using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetFullnessNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.SetFullness((float)args[0]);
    }
}
