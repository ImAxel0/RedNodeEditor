using System.Xml.Serialization;
using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class LocalPlayerNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public LocalPlayer LocalPlayer { get; set; }

    public override void Execute()
    {
        LocalPlayer = LocalPlayer._instance;
    }
}
