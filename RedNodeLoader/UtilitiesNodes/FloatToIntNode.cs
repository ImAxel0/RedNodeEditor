namespace RedNodeLoader.UtilitiesNodes;

public class FloatToIntNode : SonsNode
{
    [IsArgOut]
    public int Converted { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Converted = Convert.ToInt32((float)args[0]);
    }
}
