namespace RedNodeLoader.MathNodes;

public class EqualIntNode : SonsNode
{
    public int First { get; set; }
    public int Second { get; set; }

    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = (int)args[0] == (int)args[1];
    }
}
