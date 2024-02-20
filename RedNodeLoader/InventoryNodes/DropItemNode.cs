using TheForest.Utils;
using UnityEngine;

namespace RedNodeLoader.InventoryNodes;

public class DropItemNode : SonsNode
{
    public int ItemId { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer.Inventory.DropItemFromInventory((int)args[0], out GameObject outResultingItem);
    }
}
