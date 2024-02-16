using IconFonts;

namespace RedNodeEditor.RedNodes;

public class OnInitializeMod : SonsNode
{
    public OnInitializeMod()
    {
        Name = $"OnInitializeMod {FontAwesome6.RightLong}";
        Description = "This node will be executed right before loading into the main menu. " +
            "It only gets executed one time";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
