using static SUI.SUI;

namespace RedNodeLoader.UI;

public class SetOverrideSortingNode : SonsNode
{
    public string PanelId { get; set; }
    public int Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var panel = GetPanel((string)args[0]);
        panel.OverrideSorting((int)args[1]);
    }
}
