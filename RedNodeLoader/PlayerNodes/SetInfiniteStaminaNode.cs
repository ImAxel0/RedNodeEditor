using TheForest;

namespace RedNodeLoader.PlayerNodes;

public class SetInfiniteStaminaNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var onoff = (bool)args[0] ? "on" : "off";
        DebugConsole.Instance._energyhack(onoff);
    }
}
