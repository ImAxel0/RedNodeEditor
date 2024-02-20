using Sons.Items.Core;
using System.Xml.Serialization;

namespace RedNodeLoader.InventoryNodes;

public class GetItemByIdNode : SonsNode
{
    public int ItemId { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public ItemData ItemData { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ItemData = ItemDatabaseManager.ItemById((int)args[0]);
    }
}
