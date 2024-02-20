using System.Xml.Serialization;
using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GetCamRotatorNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public SimpleMouseRotator Rotator { get; set; }

    public override void Execute()
    {
        Rotator = LocalPlayer.CamRotator;
    }
}
