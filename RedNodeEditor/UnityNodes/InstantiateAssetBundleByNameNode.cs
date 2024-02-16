using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class InstantiateAssetBundleByNameNode : SonsNode
{
    public string BundleName { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    public InstantiateAssetBundleByNameNode()
    {
        Name = "InstantiateAssetBundleByName";
        Description = "Instantiate a loaded asset bundle as a gameobject at the given position and rotation. Outputs the instantiated GameObject\n" +
            "Better use [InstantiateObject] to avoid spelling errors in the name";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(BundleName) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Pos) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rot) });
        ArgsOut.Add(new ArgOut { Type = typeof(GameObject) });
    }
}
