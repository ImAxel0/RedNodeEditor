using Sons.Atmosphere;

namespace RedNodeLoader.EnvironmentNodes;

public class SetWindForceNode : SonsNode
{
    public float Force { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);

        if ((float)args[0] < 0)
        {
            WindManager.Unlock();
            return;
        }
        WindManager.SetAndLockIntensity((float)args[0]);
    }
}
