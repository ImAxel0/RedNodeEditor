using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class GetWorldPositionNode : SonsNode
{
    [IsArgOut]
    public Vector3 Position { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        Position = new Vector3(tr.position.x, tr.position.y, tr.position.z);
    }
}
