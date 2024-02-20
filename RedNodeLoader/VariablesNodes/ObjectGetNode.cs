namespace RedNodeLoader.VariablesNodes;

[IsGetVariable]
public class ObjectGetNode : SonsNode
{
    [IsArgOut]
    public object Value { get; set; } = null;

    public override void Execute()
    {
        var setNode = (ObjectSetNode)RedNodeLoader.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
