namespace RedNodeEditor.UtilitiesNodes;

public class IntToStringNode : SonsNode
{
    public IntToStringNode()
    {
        Name = "IntToString";
        Description = "Convert integer input to string output";
        NodeCategory = NodeCategories.Utilities;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = "int" });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
