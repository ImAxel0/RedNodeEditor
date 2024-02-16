using IconFonts;

namespace RedNodeEditor.RedNodes;

public class OnGameStart : SonsNode
{
    public OnGameStart()
    {
        Name = $"OnGameStart {FontAwesome6.Gamepad}";
        Description = "The node will be executed right after finishing loading into a savegame, executing all subsequent attached nodes." +
            " It will be executed again if switching savegame";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
