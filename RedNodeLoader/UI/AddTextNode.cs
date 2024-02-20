using static RedNodeLoader.AXSUI;
using static SUI.SUI;

namespace RedNodeLoader.UI;

public class AddTextNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }
    public int FontSize { get; set; } = 18;
    public string Color { get; set; } = "#ffffff";

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var panel = GetPanel((string)args[0]);
        AxGetMainContainer(panel)
            .Add(AxText($"<color={(string)args[3]}>{(string)args[1]}</color>", (int)args[2]));
        IdOut = (string)args[0];
    }
}
