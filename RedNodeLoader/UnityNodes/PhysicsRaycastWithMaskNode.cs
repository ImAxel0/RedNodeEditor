using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class PhysicsRaycastWithMaskNode : SonsNode
{
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; }
    public float MaxDistance { get; set; }
    public string LayerName { get; set; }

    [IsArgOut]
    public bool WasHit { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public RaycastHit RaycastHit { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);

        var or = (Vector3)args[0];
        var dir = (Vector3)args[1];

        WasHit = Physics.Raycast(new UnityEngine.Vector3(or.X, or.Y, or.Z), new UnityEngine.Vector3(dir.X, dir.Y, dir.Z), 
            out RaycastHit hitInfo, (float)args[2], LayerMask.GetMask((string)args[3]));

        if (WasHit)
            RaycastHit = hitInfo;
    }
}
