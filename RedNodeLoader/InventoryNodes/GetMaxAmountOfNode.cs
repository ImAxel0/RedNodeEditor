using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class GetMaxAmountOfNode : SonsNode
{
    public int ItemId { get; set; }

    [IsArgOut]
    public int MaxAmount { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        MaxAmount = LocalPlayer.Inventory.GetMaxAmountOf((int)args[0]);
    }
}
