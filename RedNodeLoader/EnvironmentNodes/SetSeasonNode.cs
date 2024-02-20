using Sons.Atmosphere;

namespace RedNodeLoader.EnvironmentNodes;

public class SetSeasonNode : SonsNode
{
    public SeasonsManager.Season EnumValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        SeasonsManager.Instance.LockSeason((SeasonsManager.Season)args[0]);
    }
}
