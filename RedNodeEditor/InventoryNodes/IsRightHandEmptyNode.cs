namespace RedNodeEditor.InventoryNodes;

public class IsRightHandEmptyNode : SonsNode
{
    public IsRightHandEmptyNode()
    {
        Name = "IsRightHandEmpty";
        Description = "Checks if player right hand is equipping something";
        NodeCategory = NodeCategories.Inventory;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
