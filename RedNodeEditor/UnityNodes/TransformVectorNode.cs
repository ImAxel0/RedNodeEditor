using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class TransformVectorNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }
    public Vector3 LocalVec3 { get; set; }

    public TransformVectorNode()
    {
        Name = "TransformVector";
        Description = "Transforms vector3 from local space to world space";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(LocalVec3) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
