using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class SetStaminaNode : SonsNode
{
    public float Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Vitals.SetStamina((float)args[0]);
    }
}
