namespace RedNodeEditor.RedNodes;

public class OnInitializeMod : SonsNode
{
    public OnInitializeMod()
    {
        Name = "OnInitializeMod";
        Description = "This node will be executed right before loading into the main menu";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
