using System.Numerics;
using static RedNodeLoader.AXSUI;
using static SUI.SUI;

namespace RedNodeLoader.UI;

public class AddSliderNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }
    public Vector2 Range { get; set; }
    public float Step { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var panel = GetPanel((string)args[0]);
        var range = (Vector2)args[2];
        AxGetMainContainer(panel)
            .Add(AxMenuSliderFloat((string)args[1], LabelPosition.Top, range.X, range.Y, (range.Y / 2), (float)args[3], OnValueChange));
        IdOut = (string)args[0];
    }

    void OnValueChange(float value)
    {
        RedNodeLoader.GetCustomEvent(EventId).FloatParam = value;
        RedNodeLoader.GetCustomEvent(EventId).Execute();
    }
}
