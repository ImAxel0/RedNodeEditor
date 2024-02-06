using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class GetLocalPositionNode : SonsNode
{
    public GetLocalPositionNode()
    {
        Name = "GetLocalPosition";
        Description = "Gets the local position of the passed Transform";
        NodeCategory = NodeCategories.Unity;
        
        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
