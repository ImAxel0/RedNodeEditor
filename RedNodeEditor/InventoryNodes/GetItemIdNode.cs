using Sons.Items.Core;

namespace RedNodeEditor.InventoryNodes;

public class GetItemIdNode : SonsNode
{
    public GetItemIdNode()
    {
        Name = "GetItemId";
        Description = "Gets the item Id of the passed ItemData";
        NodeCategory = NodeCategories.Inventory;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(ItemData), ArgName = nameof(ItemData) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
