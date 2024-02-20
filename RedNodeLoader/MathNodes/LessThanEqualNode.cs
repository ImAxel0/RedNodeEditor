namespace RedNodeLoader.MathNodes;

public class LessThanEqualNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = (float)args[0] <= (float)args[1];
    }
}
