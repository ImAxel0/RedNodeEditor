using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class AddItemNode : SonsNode
{
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        LocalPlayer._instance.AddItem((int)args[0], (int)args[1]);
    }
}
