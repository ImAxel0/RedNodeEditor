using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class AmountOfNode : SonsNode
{
    public int ItemId { get; set; }

    [IsArgOut]
    public int OwnedAmount { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        OwnedAmount = LocalPlayer.Inventory.AmountOf((int)args[0]);
    }
}
