namespace RedNodeEditor.RedNodes;

public class OnGameStart : SonsNode
{
    public OnGameStart()
    {
        Name = "OnGameStart";
        Description = "The node will be executed right after finishing loading into a savegame, executing all subsequent attached nodes";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
