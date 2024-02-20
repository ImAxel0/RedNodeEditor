namespace RedNodeLoader.UtilitiesNodes;

public class IntToFloatNode : SonsNode
{
    [IsArgOut]
    public float Converted { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Converted = (float)Convert.ToDouble((int)args[0]);
    }
}
