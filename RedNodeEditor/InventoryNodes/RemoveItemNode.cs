namespace RedNodeEditor.InventoryNodes;

public class RemoveItemNode : SonsNode
{
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public RemoveItemNode()
    {
        Name = "RemoveItem";
        Description = "Removes an item from inventory of given amount";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Amount) });
    }
}
