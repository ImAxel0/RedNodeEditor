namespace RedNodeEditor.InventoryNodes;

public class OwnsItemNode : SonsNode
{
    public int ItemId { get; set; }

    public OwnsItemNode()
    {
        Name = "OwnsItem";
        Description = "Checks if player owns given ItemId";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
