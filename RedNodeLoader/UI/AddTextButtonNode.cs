using static RedNodeLoader.AXSUI;
using static SUI.SUI;

namespace RedNodeLoader.UI;

public class AddTextButtonNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }
    public int FontSize { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var panel = GetPanel((string)args[0]);
        AxGetMainContainer(panel)
            .Add(AxMenuButtonText((string)args[1], RedNodeLoader.GetCustomEvent(EventId).Execute, (int)args[2])).Dock(SUI.EDockType.Fill);
        IdOut = (string)args[0];
    }
}
