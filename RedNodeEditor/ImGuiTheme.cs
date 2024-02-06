using System.Numerics;
using ImGuiNET;

namespace RedNodeEditor;

public class ImGuiTheme
{
    public static ImGuiStylePtr ImGuiStyle;

    static float _childRounding = 0;
    static float _frameRounding = 0;
    static float _frameBorder = 0;
    static Vector4 _childBgColor = new(0.2f, 0.2f, 0.2f, 1);
    static Vector4 _headersColor = new(0.3f, 0.3f, 0.3f, 1);
    static Vector4 _frameColor = new(0.13f, 0.13f, 0.13f, 1);

    public static void ApplyTheme()
    {
        ImGuiStyle.ChildRounding = _childRounding;
        ImGuiStyle.FrameRounding = _frameRounding;
        ImGuiStyle.FrameBorderSize = _frameBorder;
        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = _childBgColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Border] = new(.23f, .23f, .23f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = _frameColor * 2;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = _frameColor;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = _frameColor;
        ImGuiStyle.Colors[(int)ImGuiCol.SeparatorHovered] = Drawings.Colors.SelectedNodeColor;
        ImGuiStyle.Colors[(int)ImGuiCol.SeparatorActive] = Drawings.Colors.SelectedNodeColor;
        ImGuiStyle.Colors[(int)ImGuiCol.Button] = Drawings.Colors.Green;
        ImGuiStyle.Colors[(int)ImGuiCol.ButtonHovered] = Drawings.Colors.Green * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.ButtonActive] = Drawings.Colors.Green;
        ImGuiStyle.Colors[(int)ImGuiCol.TitleBg] = _childBgColor;
        ImGuiStyle.Colors[(int)ImGuiCol.TitleBgActive] = _childBgColor;
    }

    public static void EditorTheme()
    {
        ImGuiStyle.ChildRounding = _childRounding;
        ImGuiStyle.FrameRounding = _frameRounding;
        ImGuiStyle.FrameBorderSize = _frameBorder;
        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new(0.13f, 0.13f, 0.13f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = Drawings.Colors.Green * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = Drawings.Colors.Green;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = Drawings.Colors.Green;
    }

    public static void NodeTheme(SonsNode node)
    {
        ImGuiStyle.ChildRounding = 5;
        ImGuiStyle.FrameRounding = 5;
        ImGuiStyle.FrameBorderSize = 1;
        Vector4 col = (node.NodeType == SonsNode.NodeTypes.Starter) ? new(0.48f, 0.16f, 0.16f, .8f) : new(0.24f, 0.24f, 0.24f, .8f);
        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = col;
        ImGuiStyle.Colors[(int)ImGuiCol.Border] = new Vector4(0, 0, 0, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.16f, 0.16f, 0.16f, 1) * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = new(0.16f, 0.16f, 0.16f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = new(0.16f, 0.16f, 0.16f, 1);      
    }

    public static void LoggerTheme()
    {
        ImGuiStyle.ChildRounding = _childRounding;
        ImGuiStyle.FrameRounding = _frameRounding;
        ImGuiStyle.FrameBorderSize = _frameBorder;
        ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new(.1f, .1f, .1f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Border] = new(.23f, .23f, .23f, 1);
        ImGuiStyle.Colors[(int)ImGuiCol.Header] = _headersColor;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderHovered] = _headersColor * 1.2f;
        ImGuiStyle.Colors[(int)ImGuiCol.HeaderActive] = _headersColor * 1.5f;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgHovered] = _frameColor * 2;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBgActive] = _frameColor;
        ImGuiStyle.Colors[(int)ImGuiCol.FrameBg] = _frameColor;
    }

    public static void CommentTheme()
    {
        ImGuiStyle.ChildRounding = 5;
        ImGuiStyle.FrameRounding = 5;
        ImGuiStyle.FrameBorderSize = 0;
    }
}
