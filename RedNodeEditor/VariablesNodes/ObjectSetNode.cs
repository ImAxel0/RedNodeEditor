namespace RedNodeEditor.VariablesNodes;

public class ObjectSetNode : SonsNode
{
    public object ValueIn { get; set; }

    public ObjectSetNode()
    {
        Name = "ObjectSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the object variable";

        ArgsIn.Add(new ArgIn { Type = typeof(object), ArgName = nameof(ValueIn) });
        ArgsOut.Add(new ArgOut { Type = typeof(object) });
    }
}
