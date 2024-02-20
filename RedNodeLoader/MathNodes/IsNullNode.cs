namespace RedNodeLoader.MathNodes;

public class IsNullNode : SonsNode
{
    [IsArgOut]
    public bool IsNull { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        IsNull = args[0] == null;
    }
}
