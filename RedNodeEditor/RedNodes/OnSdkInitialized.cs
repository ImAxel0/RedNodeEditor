using IconFonts;

namespace RedNodeEditor.RedNodes;

public class OnSdkInitialized : SonsNode
{
    public OnSdkInitialized()
    {
        Name = $"OnSdkInitialized {FontAwesome6.ScrewdriverWrench}";
        Description = "This node will be executed right after loading into the main menu. Stuff like UI creation should happen here. " +
            "It only gets executed one time";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
