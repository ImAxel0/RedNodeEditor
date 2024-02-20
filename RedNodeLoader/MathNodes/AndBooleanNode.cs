namespace RedNodeLoader.MathNodes;

public class AndBooleanNode : SonsNode
{
    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = (bool)args[0] && (bool)args[1];
    }
}
