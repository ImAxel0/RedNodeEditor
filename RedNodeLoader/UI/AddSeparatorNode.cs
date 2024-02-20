using static RedNodeLoader.AXSUI;
using static SUI.SUI;

namespace RedNodeLoader.UI;

public class AddSeparatorNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; } = "";

    public string TextColor { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var panel = GetPanel((string)args[0]);
        AxGetMainContainer(panel)
            .Add(AxDivider($"<color={(string)args[2]}>{(string)args[1]}</color>"));
        IdOut = (string)args[0];
    }
}
