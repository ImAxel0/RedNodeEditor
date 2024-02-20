using static RedNodeLoader.AXSUI;
using static SUI.SUI;

namespace RedNodeLoader.UI;

public class AddButtonNode : SonsNode
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
            .Add(AxMenuButton((string)args[1], RedNodeLoader.GetCustomEvent(EventId).Execute));
        IdOut = (string)args[0];
    }
}
