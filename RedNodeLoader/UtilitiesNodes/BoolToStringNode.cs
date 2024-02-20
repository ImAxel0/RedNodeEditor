namespace RedNodeLoader.UtilitiesNodes;

public class BoolToStringNode : SonsNode
{
    [IsArgOut]
    public string Converted { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Converted = Convert.ToString((bool)args[0]);
    }
}
