using IconFonts;

namespace RedNodeEditor.RedNodes;

public class OnUpdate : SonsNode
{
    public OnUpdate()
    {
        Name = $"OnUpdate {FontAwesome6.Infinity}";
        Description = "This node is called every frame, basically always";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
