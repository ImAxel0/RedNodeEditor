namespace RedNodeEditor.VariablesNodes;

public class IntSetNode : SonsNode
{
    public int ValueIn { get; set; }

    public IntSetNode()
    {
        Name = "IntSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the integer variable";

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ValueIn) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
