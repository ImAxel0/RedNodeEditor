namespace RedNodeEditor.VariablesNodes;

public class IntGetNode : SonsNode
{
    public IntGetNode()
    {
        Name = "IntGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the integer variable";

        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
