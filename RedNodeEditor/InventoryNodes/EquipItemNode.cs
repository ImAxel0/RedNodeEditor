namespace RedNodeEditor.InventoryNodes;

public class EquipItemNode : SonsNode
{
    public int ItemId { get; set; }

    public EquipItemNode()
    {
        Name = "EquipItem";
        Description = "Tries to equip the given item in hands";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
    }
}
