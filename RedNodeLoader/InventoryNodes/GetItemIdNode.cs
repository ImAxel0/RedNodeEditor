using Sons.Items.Core;

namespace RedNodeLoader.InventoryNodes;

public class GetItemIdNode : SonsNode
{
    [IsArgOut]
    public int ItemId { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var itemdata = (ItemData)args[0];
        ItemId = itemdata.Id;
    }
}
