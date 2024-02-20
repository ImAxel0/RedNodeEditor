namespace RedNodeLoader.UI;

public class CreateSidePanelNode : SonsNode
{
    public string PanelId { get; set; }
    public string Title { get; set; }
    public bool CanResize { get; set; }
    public float HSize { get; set; }
    public bool InputEnabled { get; set; }
    public Side EnumValue { get; set; }

    [IsArgOut]
    public string IdOut { get; set; }

    public enum Side
    {
        Left, Right
    }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        AXSUI.AxCreateSidePanel((string)args[0], (bool)args[2], (string)args[1], (AXSUI.Side)args[5], (float)args[3], null, SUI.EBackground.None, (bool)args[4]);
        IdOut = (string)args[0];
    }
}
