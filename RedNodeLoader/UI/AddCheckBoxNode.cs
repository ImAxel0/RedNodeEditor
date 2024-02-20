using static RedNodeLoader.AXSUI;
using static SUI.SUI;

namespace RedNodeLoader.UI;

public class AddCheckBoxNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var panel = GetPanel((string)args[0]);
        AxGetMainContainer(panel)
            .Add(AxMenuCheckBox((string)args[1], OnValueChange));
        IdOut = (string)args[0];
    }

    void OnValueChange(bool value)
    {
        RedNodeLoader.GetCustomEvent(EventId).BoolParam = value;
        RedNodeLoader.GetCustomEvent(EventId).Execute();
    }
}
