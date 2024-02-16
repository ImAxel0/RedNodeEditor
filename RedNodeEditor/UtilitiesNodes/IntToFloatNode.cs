namespace RedNodeEditor.UtilitiesNodes;

public class IntToFloatNode : SonsNode
{
    public IntToFloatNode()
    {
        Name = "IntToFloat";
        Description = "Convert int input to float output";
        NodeCategory = NodeCategories.Utilities;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = "int" });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
