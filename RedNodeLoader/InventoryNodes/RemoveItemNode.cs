using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class RemoveItemNode : SonsNode
{
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Inventory.RemoveItem((int)args[0], (int)args[1]);
    }
}
