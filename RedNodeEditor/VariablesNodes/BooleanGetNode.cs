namespace RedNodeEditor.VariablesNodes;

public class BooleanGetNode : SonsNode
{
    public BooleanGetNode()
    {
        Name = "BoolGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the boolean variable";

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
