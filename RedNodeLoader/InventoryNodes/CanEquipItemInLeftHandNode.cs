using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class CanEquipItemInLeftHandNode : SonsNode
{
    public int ItemId { get; set; }

    [IsArgOut]
    public bool CanEquip { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        CanEquip = LocalPlayer.Inventory.CanEquipItemInLeftHand((int)args[0]);
    }
}
