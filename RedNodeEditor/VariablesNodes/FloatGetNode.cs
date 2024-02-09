namespace RedNodeEditor.VariablesNodes;

public class FloatGetNode : SonsNode
{
    public FloatGetNode()
    {
        Name = "FloatGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the float variable";

        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
