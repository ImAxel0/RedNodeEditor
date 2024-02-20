using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class RemoveAllItemsNode : SonsNode
{
    public override void Execute()
    {
        LocalPlayer.Inventory.RemoveAllItems();
    }
}
