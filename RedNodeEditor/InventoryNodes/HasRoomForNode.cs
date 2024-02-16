namespace RedNodeEditor.InventoryNodes;

public class HasRoomForNode : SonsNode
{
    public int ItemId { get; set; }
    public int Amount { get; set; } = 1;

    public HasRoomForNode()
    {
        Name = "HasRoomFor";
        Description = "Check if player can get more of the given item id and said amount";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Amount) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
