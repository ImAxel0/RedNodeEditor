namespace RedNodeEditor.InventoryNodes;

public class DropItemNode : SonsNode
{
    public int ItemId { get; set; }

    public DropItemNode()
    {
        Name = "DropItem";
        Description = "Drops the passed item id if has any";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
    }
}
