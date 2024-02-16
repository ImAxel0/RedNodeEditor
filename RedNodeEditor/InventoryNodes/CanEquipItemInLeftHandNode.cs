namespace RedNodeEditor.InventoryNodes;

public class CanEquipItemInLeftHandNode : SonsNode
{
    public int ItemId { get; set; }

    public CanEquipItemInLeftHandNode()
    {
        Name = "CanEquipItemInLeftHand";
        Description = "Check if player can currently equip given item id in left hand";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
