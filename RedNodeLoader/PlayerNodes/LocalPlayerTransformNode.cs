using System.Xml.Serialization;
using TheForest.Utils;
using UnityEngine;

namespace RedNodeLoader.PlayerNodes;

public class LocalPlayerTransformNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Transform Transform { get; set; }

    public override void Execute()
    {
        Transform = LocalPlayer.Transform;
    }
}
