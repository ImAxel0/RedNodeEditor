namespace RedNodeLoader.VariablesNodes;

[IsGetVariable]
public class FloatGetNode : SonsNode
{
    [IsArgOut]
    public float Value { get; set; }

    public override void Execute()
    {
        var setNode = (FloatSetNode)RedNodeLoader.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
