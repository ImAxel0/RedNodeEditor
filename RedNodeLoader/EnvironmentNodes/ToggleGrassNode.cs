using TheForest;

namespace RedNodeLoader.EnvironmentNodes;

public class ToggleGrassNode : SonsNode
{
    public override void Execute()
    {
        DebugConsole.Instance.SendCommand("togglegrass");
    }
}
