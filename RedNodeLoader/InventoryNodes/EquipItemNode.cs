using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class EquipItemNode : SonsNode
{
    public int ItemId { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Inventory.TryEquip((int)args[0], false);
    }
}
