using Sons.Environment;
using TheForest;

namespace RedNodeLoader.EnvironmentNodes;

public class LockTimeNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LockDaytime((bool)args[0]);
    }

    static void LockDaytime(bool onoff)
    {
        if (onoff)
        {
            int hour = TimeOfDayHolder.GetTimeOfDay().Hours;
            int minutes = TimeOfDayHolder.GetTimeOfDay().Minutes;
            DebugConsole.Instance._lockTimeOfDay($"{hour}:{minutes}");
            return;
        }
        int hour1 = TimeOfDayHolder.GetTimeOfDay().Hours;
        int minutes1 = TimeOfDayHolder.GetTimeOfDay().Minutes;
        DebugConsole.Instance._setTimeOfDay($"{hour1}:{minutes1}");
    }
}
