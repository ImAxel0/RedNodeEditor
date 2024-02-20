using Sons.Items.Core;
using System.Xml.Serialization;
using TheForest.Utils;

namespace RedNodeLoader.InventoryNodes;

public class GetRightHandItemNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public ItemData ItemData { get; set; }

    public override void Execute()
    {
        ItemData = LocalPlayer.Inventory.RightHandItem?.Data;
    }
}
