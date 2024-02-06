namespace RedNodeEditor.PlayerNodes;

public class GetStaminaNode : SonsNode
{
    public GetStaminaNode()
    {
        Name = "GetStamina";
        Description = "Returns player current stamina value";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
