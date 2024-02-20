namespace RedNodeLoader.VariablesNodes;

[IsGetVariable]
public class StringGetNode : SonsNode
{
    [IsArgOut]
    public string Value { get; set; }

    public override void Execute()
    {
        var setNode = (StringSetNode)RedNodeLoader.GetNodeById(this.Id);
        Value = setNode.ValueOut;
    }
}
