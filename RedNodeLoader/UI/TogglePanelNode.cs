using static SUI.SUI;

namespace RedNodeLoader.UI;

public class TogglePanelNode : SonsNode
{
    public string PanelId { get; set; }
    public bool Value { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        TogglePanel((string)args[0], (bool)args[1]);
        IdOut = (string)args[0];
    }
}
