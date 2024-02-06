using Sons.Items.Core;

namespace RedNodeEditor.InventoryNodes;

public class GetRightHandItemNode : SonsNode
{
    public GetRightHandItemNode()
    {
        Name = "GetRightHandItem";
        Description = "Gets ItemData class of the held right hand item if one is equipped, else NULL";
        NodeCategory = NodeCategories.Inventory;

        ArgsOut.Add(new ArgOut { Type = typeof(ItemData) });
    }
}
