namespace RedNodeEditor.InputNodes;

public class GetAxisRawNode : SonsNode
{
    public string AxisName { get; set; }

    public GetAxisRawNode()
    {
        Name = "GetAxisRaw";
        Description = "Returns a value between -1 and 1 for keyboard and joystick input devices." +
            " For the mouse it will return the current mouse delta multiplied by the axis sensitivity." +
            " The returned value won't have any smoothing filtering applied.";
        NodeCategory = NodeCategories.Input;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(AxisName) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
