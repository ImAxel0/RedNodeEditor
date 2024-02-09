namespace RedNodeEditor.VariablesNodes;

public class BooleanSetNode : SonsNode
{
    public bool ValueIn { get; set; }

    public BooleanSetNode() 
    {
        Name = "BoolSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the boolean variable";

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(ValueIn) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
