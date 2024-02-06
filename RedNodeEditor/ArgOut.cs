using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;
using System.Xml.Serialization;
using Vector2 = System.Numerics.Vector2;

namespace RedNodeEditor;

public class ArgOut
{
    [XmlIgnore]
    /// <summary>
    /// The node of this output argument
    /// </summary>
    public SonsNode SonsNode { get; set; }

    [XmlIgnore]
    /// <summary>
    /// To which node is this output argument connected?
    /// </summary>
    public SonsNode ConnectedNode { get; set; }

    [XmlIgnore]
    public Vector2 Position { get; set; }

    [XmlIgnore]
    public bool IsDragging;

    [XmlIgnore]
    /// <summary>
    /// Is this output argument connected to an input argument?
    /// </summary>
    public bool HasConnection;

    [XmlIgnore]
    [JsonIgnore]
    public float Radius = 7;

    [XmlIgnore]
    /// <summary>
    /// The input argument to which this output argument is connected
    /// </summary>
    public ArgIn InputArg { get; set; }

    [XmlIgnore]
    public Type Type { get; set; }

    public string PassTo { get; set; }

    public void Render(SonsNode node)
    {
        SonsNode = node;
        Position = new Vector2(ImGui.GetCursorScreenPos().X + Radius, ImGui.GetCursorScreenPos().Y + Radius);

        if (HasConnection && Utilities.IsMouseHovering(Position, Radius) && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Right))
            GraphEditor.DisconnectArgs(this, InputArg);

        Drawings.InOutTooltip(Utilities.IsMouseHovering(Position, Radius), Type.Name);

        var typeColor = Drawings.GetTypeColor(Type);

        if (Utilities.IsMouseHovering(Position, Radius))
        {
            ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
            Drawings.DrawOutlineGlow(Radius, 1f, ImGui.GetColorU32(new Vector4(typeColor.X, typeColor.Y, typeColor.Z, 0.1f)));
        }

        if (HasConnection)
            Drawings.DrawFilledCircle(Radius, ImGui.GetColorU32(typeColor));
        else
            Drawings.DrawEmptyCircle(Radius, ImGui.GetColorU32(typeColor));
          
        if (ImGui.IsMouseDown(ImGuiMouseButton.Right) && !IsDragging && !GraphEditor.DraggingOutput)
            GraphEditor.DraggingOutput = IsDragging = ImGui.IsMouseDown(ImGuiMouseButton.Right) && Utilities.IsMouseHovering(Position, Radius);

        else if (!ImGui.IsMouseDown(ImGuiMouseButton.Right) && IsDragging)
            GraphEditor.DraggingOutput = IsDragging = false;
    }
}
