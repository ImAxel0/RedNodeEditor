using Sons.Environment;

namespace RedNodeLoader.EnvironmentNodes;

public class SetTimeMultiplierNode : SonsNode
{
    public float Multiplier { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        TimeOfDayHolder.SetBaseTimeSpeed((float)args[0]);
    }
}
