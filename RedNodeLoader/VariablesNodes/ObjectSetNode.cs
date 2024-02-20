namespace RedNodeLoader.VariablesNodes;

public class ObjectSetNode : SonsNode
{
    public object ValueIn { get; set; }

    [IsArgOut]
    public object ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ValueOut = (object)args[0];
        RedNodeLoader.ReplaceIdNodePair(RedNodeLoader.IdNodePair, this.Id, this.Id, this);
    }
}
