namespace RedNodeEditor.UtilitiesNodes;

public class FloatToIntNode : SonsNode
{
    public FloatToIntNode()
    {
        Name = "FloatToInt";
        Description = "Convert float input to integer output";
        NodeCategory = NodeCategories.Utilities;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "float" });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
