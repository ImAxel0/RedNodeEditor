using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class IsRightHandEmptyNode : SonsNode
{
    [IsArgOut]
    public bool IsEmpty { get; set; }

    public override void Execute()
    {
        IsEmpty = LocalPlayer.Inventory.IsRightHandEmpty();
    }
}
