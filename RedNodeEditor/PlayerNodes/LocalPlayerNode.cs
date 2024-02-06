using TheForest.Utils;

namespace RedNodeEditor.PlayerNodes;

public class LocalPlayerNode : SonsNode
{
    public LocalPlayerNode()
    {
        Name = "LocalPlayer";
        Description = "Gets the LocalPlayer instance";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(LocalPlayer) });
    }
}
