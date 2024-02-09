namespace RedNodeEditor.VariablesNodes;

public class FloatSetNode : SonsNode
{
    public float ValueIn { get; set; }

    public FloatSetNode()
    {
        Name = "FloatSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the float variable";

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(ValueIn) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
