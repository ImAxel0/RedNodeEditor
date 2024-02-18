using IconFonts;

namespace RedNodeEditor.RedNodes;

public class OnFixedUpdate : SonsNode
{
    public OnFixedUpdate()
    {
        Name = $"OnFixedUpdate {FontAwesome6.PersonRunning}";
        Description = "This node is mainly used for physics based calculations, like moving objects around using rigidbodies";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BaseNodes;
    }
}
