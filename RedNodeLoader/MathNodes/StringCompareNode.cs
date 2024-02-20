namespace RedNodeLoader.MathNodes;

public class StringCompareNode : SonsNode
{
    public string First { get; set; }
    public string Second { get; set; }

    [IsArgOut]
    public bool Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = (string)args[0] == (string)args[1];
    }
}
