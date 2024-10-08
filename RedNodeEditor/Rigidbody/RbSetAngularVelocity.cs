﻿using System.Xml.Serialization;
using System.Numerics;

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbSetAngularVelocity : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Velocity { get; set; }

    public RbSetAngularVelocity()
    {
        Name = nameof(RbSetAngularVelocity);
        Description = "Sets the angular velocity vector of the rigidbody measured in radians per second.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Velocity) });
    }
}
