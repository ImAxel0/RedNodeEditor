using Sons.Items.Core;
using System.Xml.Serialization;

namespace RedNodeEditor.InventoryNodes;

public class SetMaxAmountNode : SonsNode
{
    [XmlIgnore]
    public ItemData ItemData { get; set; }
    public int MaxAmount { get; set; }

    public SetMaxAmountNode()
    {
        Name = "SetMaxAmount";
        Description = "Sets max ownable amount of passed itemdata";
        NodeCategory = NodeCategories.Inventory;

        ArgsIn.Add(new ArgIn { Type = typeof(ItemData), ArgName = nameof(ItemData) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(MaxAmount) });
    }
}
