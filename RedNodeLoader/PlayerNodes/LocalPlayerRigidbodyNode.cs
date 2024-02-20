using System.Xml.Serialization;
using TheForest.Utils;
using UnityEngine;

namespace RedNodeLoader.PlayerNodes;

public class LocalPlayerRigidbodyNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Rigidbody Rigidbody { get; set; }

    public override void Execute()
    {
        Rigidbody = LocalPlayer.Rigidbody;
    }
}
