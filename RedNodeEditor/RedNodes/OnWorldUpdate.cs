using IconFonts;

namespace RedNodeEditor.RedNodes;

public class OnWorldUpdate : SonsNode
{
    public OnWorldUpdate()
    {
        Name = $"OnWorldUpdate {FontAwesome6.EarthEurope}";
        Description = "Called every frame when in world (not inventory, caves), basically always when in world";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
