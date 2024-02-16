using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;
using System.Xml.Serialization;

namespace RedNodeEditor;

public class ArgIn
{
    public string ArgName { get; set; } = "";

    [XmlIgnore]
    /// <summary>
    /// The node of this input argument
    /// </summary>
    public SonsNode SonsNode { get; set; }

    [XmlIgnore]
    /// <summary>
    /// To which node is this input argument connected?
    /// </summary>
    public SonsNode ConnectedNode { get; set; }

    [XmlIgnore]
    public Vector2 Position { get; set; }
  
    /// <summary>
    /// Is this input argument connected to an output argument?
    /// </summary>
    public bool HasConnection;

    [XmlIgnore]
    [JsonIgnore]
    public float Radius = 7;

    [XmlIgnore]
    /// <summary>
    /// The output argument to which this input argument is connected
    /// </summary>
    public ArgOut OutputArg { get; set; }

    [XmlIgnore]
    public Type Type { get; set; }

    /// <summary>
    /// the ID of the node from which the argument arrives
    /// </summary>
    public string ReceiveFrom { get; set; }

    /// <summary>
    /// the argument output index of the ReceiveFrom node
    /// </summary>
    public int ReceiveFromIndex { get; set; }

    [XmlIgnore]
    public bool Hide { get; set; }

    public void Render(SonsNode node)
    {
        SonsNode = node;
        Position = new Vector2(ImGui.GetCursorScreenPos().X + Radius, ImGui.GetCursorScreenPos().Y + Radius);

        Drawings.InOutTooltip(Utilities.IsMouseHovering(Position, Radius), Type.Name);

        var typeColor = Drawings.GetTypeColor(Type);

        if (Utilities.IsMouseHovering(Position, Radius))
        {
            Drawings.DrawOutlineGlow(Radius, 1f, ImGui.GetColorU32(new Vector4(typeColor.X, typeColor.Y, typeColor.Z, 0.1f)));
            if (HasConnection)
                ImGui.SetMouseCursor(ImGuiMouseCursor.NotAllowed);
        }

        if (HasConnection)
            Drawings.DrawFilledCircle(Radius, ImGui.GetColorU32(typeColor));
        else
            Drawings.DrawEmptyCircle(Radius, ImGui.GetColorU32(typeColor));

        ImGui.SetCursorScreenPos(new(ImGui.GetCursorScreenPos().X + 20 * GraphEditor.Zoom, ImGui.GetCursorScreenPos().Y));
        ImGui.Text(ArgName);
    }
}
