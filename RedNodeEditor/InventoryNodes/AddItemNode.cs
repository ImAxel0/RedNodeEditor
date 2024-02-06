namespace RedNodeEditor.InventoryNodes;

public class AddItemNode : SonsNode
{
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public AddItemNode()
    {
        Name = "AddItem";
        Description = "Add item to inventory of specified amount";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Amount) });
    }
}
