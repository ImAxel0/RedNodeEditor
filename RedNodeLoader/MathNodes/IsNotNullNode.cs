namespace RedNodeLoader.MathNodes;

public class IsNotNullNode : SonsNode
{
    [IsArgOut]
    public bool IsNotNull { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        IsNotNull = args[0] != null;
    }
}
