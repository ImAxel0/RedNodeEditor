namespace RedNodeEditor.UtilitiesNodes;

public class FloatToStringNode : SonsNode
{
    public FloatToStringNode()
    {
        Name = "FloatToString";
        Description = "Convert float input to string output";
        NodeCategory = NodeCategories.Utilities;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "float" });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
