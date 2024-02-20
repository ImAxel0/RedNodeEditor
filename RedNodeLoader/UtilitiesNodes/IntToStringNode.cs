namespace RedNodeLoader.UtilitiesNodes;

public class IntToStringNode : SonsNode
{
    [IsArgOut]
    public string Converted { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Converted = Convert.ToString((int)args[0]);
    }
}
