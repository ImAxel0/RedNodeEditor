using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class InstantiateAssetBundleByNameNode : SonsNode
{
    public string BundleName { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public GameObject Instantiated { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var pos = (Vector3)args[1];
        var rot = (Vector3)args[2];
        Instantiated = UnityEngine.Object.Instantiate(RedNodeLoader.AssetBundleGameObjects.Find(x => x.name == (string)args[0]), 
            new UnityEngine.Vector3(pos.X, pos.Y, pos.Z), Quaternion.Euler(new UnityEngine.Vector3(rot.X, rot.Y, rot.Z)));
    }
}
