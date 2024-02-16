namespace RedNodeEditor.InventoryNodes;

public class CanEquipItemInRightHandNode : SonsNode
{
    public int ItemId { get; set; }

    public CanEquipItemInRightHandNode()
    {
        Name = "CanEquipItemInRightHand";
        Description = "Check if player can currently equip given item id in right hand";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
