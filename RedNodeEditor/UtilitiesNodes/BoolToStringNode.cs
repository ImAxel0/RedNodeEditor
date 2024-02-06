namespace RedNodeEditor.UtilitiesNodes;

public class BoolToStringNode : SonsNode
{
    public BoolToStringNode()
    {
        Name = "BoolToString";
        Description = "Convert boolean input to string output";
        NodeCategory = NodeCategories.Utilities;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = "bool" });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
