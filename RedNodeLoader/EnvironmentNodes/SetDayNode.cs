using Sons.Environment;

namespace RedNodeLoader.EnvironmentNodes;

public class SetDayNode : SonsNode
{
    public int Day { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        TimeOfDayHolder.SetDay((int)args[0]);
    }
}
