namespace RedNodeLoader.VariablesNodes;

public class IntSetNode : SonsNode
{
    public int ValueIn { get; set; }

    [IsArgOut]
    public int ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ValueOut = (int)args[0];
        RedNodeLoader.ReplaceIdNodePair(RedNodeLoader.IdNodePair, this.Id, this.Id, this);
    }
}
