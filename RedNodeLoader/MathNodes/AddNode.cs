namespace RedNodeLoader.MathNodes;

public class AddNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    [IsArgOut]
    public float Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = (float)args[0] + (float)args[1];
    }
}
