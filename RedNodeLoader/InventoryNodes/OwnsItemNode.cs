using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class OwnsItemNode : SonsNode
{
    public int ItemId { get; set; }

    [IsArgOut]
    public bool Owns { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Owns = LocalPlayer.Inventory.Owns((int)args[0]);
    }
}
