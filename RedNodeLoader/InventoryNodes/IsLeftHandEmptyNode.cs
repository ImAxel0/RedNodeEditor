using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class IsLeftHandEmptyNode : SonsNode
{
    [IsArgOut]
    public bool IsEmpty { get; set; }

    public override void Execute()
    {
        IsEmpty = LocalPlayer.Inventory.IsLeftHandEmpty();
    }
}
