namespace RedNodeEditor.VariablesNodes;

public class StringGetNode : SonsNode
{
    public StringGetNode()
    {
        Name = "StringGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the string variable";

        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
