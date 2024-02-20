using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetHydrationNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.SetHydration((float)args[0]);
    }
}
