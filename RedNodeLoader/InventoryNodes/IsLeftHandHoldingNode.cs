using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class IsLeftHandHoldingNode : SonsNode
{
    public int ItemId { get; set; }

    [IsArgOut]
    public bool IsHolding { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        IsHolding = LocalPlayer.Inventory.IsLeftHandHolding((int)args[0]);
    }
}
