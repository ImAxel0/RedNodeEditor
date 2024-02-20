namespace RedNodeLoader.MathNodes;

public class FlipBoolNode : SonsNode
{
    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = !(bool)args[0];
    }
}
