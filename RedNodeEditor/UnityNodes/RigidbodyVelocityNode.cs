using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class RigidbodyVelocityNode : SonsNode
{
    public RigidbodyVelocityNode()
    {
        Name = "Rigidbody.Velocity";
        Description = "Outputs the velocity vector of the rigidbody. It represents the rate of change of Rigidbody position";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type  = typeof(Vector3) });
    }
}
