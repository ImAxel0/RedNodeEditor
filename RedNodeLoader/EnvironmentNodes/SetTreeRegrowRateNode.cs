using Sons.Gameplay;

namespace RedNodeLoader.EnvironmentNodes;

public class SetTreeRegrowRateNode : SonsNode
{
    public float Rate { get; set; } = 0.1f;

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        UnityEngine.Object.FindObjectOfType<TreeRegrowChecker>()._regrowthFactor = (float)args[0];
    }
}
