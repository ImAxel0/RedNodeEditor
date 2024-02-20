namespace RedNodeLoader.VariablesNodes;

public class StringSetNode : SonsNode
{
    public string ValueIn { get; set; }

    [IsArgOut]
    public string ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ValueOut = (string)args[0];
        RedNodeLoader.ReplaceIdNodePair(RedNodeLoader.IdNodePair, this.Id, this.Id, this);
    }
}
