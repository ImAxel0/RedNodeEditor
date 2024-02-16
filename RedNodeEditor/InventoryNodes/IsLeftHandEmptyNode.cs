namespace RedNodeEditor.InventoryNodes;

public class IsLeftHandEmptyNode : SonsNode
{
    public IsLeftHandEmptyNode()
    {
        Name = "IsLeftHandEmpty";
        Description = "Checks if player left hand is equipping something";
        NodeCategory = NodeCategories.Inventory;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
