using System.Numerics;

namespace RedNodeLoader.VariablesNodes;

[IsGetVariable]
public class Vector3GetNode : SonsNode
{
    [IsArgOut]
    public Vector3 Value { get; set; }

    public override void Execute()
    {
        var setNode = (Vector3SetNode)RedNodeLoader.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
