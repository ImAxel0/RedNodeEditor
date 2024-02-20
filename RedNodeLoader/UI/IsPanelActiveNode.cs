using static SUI.SUI;

namespace RedNodeLoader.UI;

public class IsPanelActiveNode : SonsNode
{
    public string PanelId { get; set; }

    [IsArgOut]
    public bool IsActive { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        IsActive = GetPanel((string)args[0]).Root.activeSelf;
        IdOut = (string)args[0];
    }
}
