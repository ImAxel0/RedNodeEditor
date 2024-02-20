using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class HasRoomForNode : SonsNode
{
    public int ItemId { get; set; }
    public int Amount { get; set; }

    [IsArgOut]
    public bool HasRoom { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        HasRoom = LocalPlayer.Inventory.HasRoomFor((int)args[0], (int)args[1]);
    }
}
