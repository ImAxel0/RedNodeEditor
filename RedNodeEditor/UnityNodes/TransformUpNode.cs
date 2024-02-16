﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class TransformUpNode : SonsNode
{
    public TransformUpNode()
    {
        Name = "Transform.Up";
        Description = "Manipulate a GameObject’s position on the Y axis of the transform in world space";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
