using Newtonsoft.Json;
using System.Xml.Serialization;

namespace RedNodeEditor.UINodes;

public class CreateSidePanelNode : SonsNode
{
    public string PanelId { get; set; }
    public string Title { get; set; }
    public bool CanResize { get; set; }
    public float HSize { get; set; } = 100;
    public bool InputEnabled { get; set; }

    [IgnoreProperty]
    public Side EnumValue { get; set; } = Side.Left;

    public enum Side
    {
        Left, Right
    }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> SideList { get; set; } = new() { Side.Left, Side.Right };

    public CreateSidePanelNode()
    {
        Name = "CreateSidePanel";
        Description = "Creates a vertical side panel which can contains ui elements like checkboxes, " +
            "sliders etc and outputs the panel id as a string to chain other ui elements";

        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Title) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(CanResize) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(HSize) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(InputEnabled) });
        ArgsIn.Add(new ArgIn { Type = typeof(Side), ArgName = nameof(Side) });

        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
