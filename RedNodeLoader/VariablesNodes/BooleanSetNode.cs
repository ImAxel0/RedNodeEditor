namespace RedNodeLoader.VariablesNodes;

public class BooleanSetNode : SonsNode
{
    public bool ValueIn { get; set; }

    [IsArgOut]
    public bool ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ValueOut = (bool)args[0];
        RedNodeLoader.ReplaceIdNodePair(RedNodeLoader.IdNodePair, this.Id, this.Id, this);
    }
}
