using Sons.Items.Core;
using System.Xml.Serialization;

namespace RedNodeLoader.InventoryNodes;
public class SetMaxAmountNode : SonsNode
{
    [XmlIgnore]
    public ItemData ItemData { get; set; }

    public int MaxAmount { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var data = (ItemData)args[0];
        data.MaxAmount = (int)args[1];
    }
}
