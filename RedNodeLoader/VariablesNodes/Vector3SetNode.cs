using System.Numerics;

namespace RedNodeLoader.VariablesNodes;

public class Vector3SetNode : SonsNode
{
    public Vector3 ValueIn { get; set; }

    [IsArgOut]
    public Vector3 ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ValueOut = (Vector3)args[0];
        RedNodeLoader.ReplaceIdNodePair(RedNodeLoader.IdNodePair, this.Id, this.Id, this);
    }
}
