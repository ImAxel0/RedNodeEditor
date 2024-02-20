namespace RedNodeLoader.VariablesNodes;

[IsGetVariable]
public class IntGetNode : SonsNode
{
    [IsArgOut]
    public int Value { get; set; }

    public override void Execute()
    {
        var setNode = (IntSetNode)RedNodeLoader.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
