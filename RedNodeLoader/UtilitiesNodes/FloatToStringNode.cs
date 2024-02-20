namespace RedNodeLoader.UtilitiesNodes;

public class FloatToStringNode : SonsNode
{
    [IsArgOut]
    public string Converted { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Converted = Convert.ToString((float)args[0]);
    }
}
