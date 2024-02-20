using System.Xml.Serialization;
using TheForest.Utils;
using UnityEngine;

namespace RedNodeLoader.PlayerNodes;

public class LocalPlayerGameObjectNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public GameObject GameObject { get; set; }

    public override void Execute()
    {
        GameObject = LocalPlayer.GameObject;
    }
}
