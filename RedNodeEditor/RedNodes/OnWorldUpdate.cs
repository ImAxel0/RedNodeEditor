namespace RedNodeEditor.RedNodes;

public class OnWorldUpdate : SonsNode
{
    public OnWorldUpdate()
    {
        Name = "OnWorldUpdate";
        Description = "Called every frame when in world (not inventory, caves)";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
