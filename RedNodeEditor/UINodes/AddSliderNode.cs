using System.Numerics;

namespace RedNodeEditor.UI;

public class AddSliderNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }
    public Vector2 Range { get; set; }
    public float Step { get; set; }

    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public AddSliderNode()
    {
        Name = "AddSlider";
        Description = $"Adds a slider to the panel. Outputs the panel id as a string to chain other ui elements.\n" +
            $"When the slider is used, the associated {nameof(EventName)} (CustomEvent node) will be called passing the float value of the slider";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Label) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = nameof(Range) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Step) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventId), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
