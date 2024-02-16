namespace RedNodeEditor.InventoryNodes;

public class IsRightHandHoldingNode : SonsNode
{
    public int ItemId { get; set; }

    public IsRightHandHoldingNode()
    {
        Name = "IsRightHandHolding";
        Description = "Check if player right hand is holding given ItemId";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
