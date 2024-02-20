using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetHealthNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.SetHealth((float)args[0]);
    }
}
