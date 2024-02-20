namespace RedNodeLoader.VariablesNodes;

[IsGetVariable]
public class BooleanGetNode : SonsNode
{
    [IsArgOut] 
    public bool Value { get; set; }

    public override void Execute()
    {
        var setNode = (BooleanSetNode)RedNodeLoader.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
