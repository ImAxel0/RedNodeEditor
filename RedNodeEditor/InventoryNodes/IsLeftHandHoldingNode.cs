namespace RedNodeEditor.InventoryNodes;

public class IsLeftHandHoldingNode : SonsNode
{
    public int ItemId { get; set; }

    public IsLeftHandHoldingNode()
    {
        Name = "IsLeftHandHolding";
        Description = "Check if player left hand is holding given ItemId";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
