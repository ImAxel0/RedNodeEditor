using TheForest;

namespace RedNodeLoader.EnvironmentNodes;

public class ToggleForestNode : SonsNode
{
    public override void Execute()
    {
        DebugConsole.Instance.SendCommand("noforest");
    }
}
