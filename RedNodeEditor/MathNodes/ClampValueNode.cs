namespace RedNodeEditor.MathNodes;

public class ClampValueNode : SonsNode
{
    public float Value { get; set; }
    public float Min { get; set; }
    public float Max { get; set; }

    public ClampValueNode()
    {
        Name = $"ClampValue";
        Description = "Clamps the passed value between min and max and outputs the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Min) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Max) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
