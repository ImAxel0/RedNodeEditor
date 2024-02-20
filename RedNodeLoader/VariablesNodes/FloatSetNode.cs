namespace RedNodeLoader.VariablesNodes;

public class FloatSetNode : SonsNode
{
    public float ValueIn { get; set; }

    [IsArgOut]
    public float ValueOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        ValueOut = (float)args[0];
        RedNodeLoader.ReplaceIdNodePair(RedNodeLoader.IdNodePair, this.Id, this.Id, this);
    }
}
