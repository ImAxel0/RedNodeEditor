using Sons.Items.Core;

namespace RedNodeEditor.InventoryNodes;

public class GetItemByIdNode : SonsNode
{
    public int ItemId { get; set; }

    public GetItemByIdNode()
    {
        Name = "GetItemById";
        Description = "Gets ItemData class of the given item id";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ItemId) });
        ArgsOut.Add(new ArgOut { Type = typeof(ItemData) });
    }
}
