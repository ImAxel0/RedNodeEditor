namespace RedNodeEditor.RedNodes;

public class OnSdkInitialized : SonsNode
{
    public OnSdkInitialized()
    {
        Name = "OnSdkInitialized";
        Description = "This node will be executed right after loading into the main menu. Stuff like UI creation should happen here";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
