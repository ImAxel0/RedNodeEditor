using ImGuiNET;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace RedNodeEditor;

public class Drawings
{
    public static Vector4 LineColor = new(1, 1, 1, 0.8f);
    public static float LineTickness = 2;

    public struct Colors
    {
        public static Vector4 White = new(1, 1, 1, 1);
        public static Vector4 Warning = new(1.00f, 0.76f, 0.30f, 1);
        public static Vector4 Error = new(0.96f, 0.38f, 0.42f, 1);
        public static Vector4 SelectedNodeColor = new(1, 0, 0.28f, 0.8f);
        public static Vector4 Green = new(0.07f, 0.48f, 0.26f, 1);

        public Colors()
        {

        }
    }

    public static void DrawNodeLine(Vector2 p1, Vector2 p2)
    {
        var dl = ImGui.GetWindowDrawList();
        float distance = (float)Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        float delta = distance * 0.45f;
        if (p2.X<p1.X) delta += 0.2f * (p1.X - p2.X);
        // float vert = (p2.x < p1.x - 20.f) ? 0.062f * distance * (p2.y - p1.y) * 0.005f : 0.f;
        float vert = 0;
        Vector2 p22 = p2 - new Vector2(delta, vert);
        if (p2.X<p1.X - 50f) delta *= -1f;
        Vector2 p11 = p1 + new Vector2(delta, vert);
        dl.AddBezierCubic(p1, p11, p22, p2, ImGui.GetColorU32(LineColor), LineTickness * GraphEditor.Zoom);
    }

    public static void DrawNodeArgumentLine(Vector2 p1, Vector2 p2, Vector4 color)
    {
        var dl = ImGui.GetWindowDrawList();
        float distance = (float)Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        float delta = distance * 0.45f;
        if (p2.X<p1.X) delta += 0.2f * (p1.X - p2.X);
        // float vert = (p2.x < p1.x - 20.f) ? 0.062f * distance * (p2.y - p1.y) * 0.005f : 0.f;
        float vert = 0;
        Vector2 p22 = p2 - new Vector2(delta, vert);
        if (p2.X<p1.X - 50f) delta *= -1f;
        Vector2 p11 = p1 + new Vector2(delta, vert);
        dl.AddBezierCubic(p1, p11, p22, p2, ImGui.GetColorU32(color), (LineTickness - 0.5f) * GraphEditor.Zoom);
    }

    public static void DrawFilledCircle(float radius, uint color, int segments = 50)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + radius * GraphEditor.Zoom, cursorScreenPos.Y + radius);

        ImGui.GetWindowDrawList().AddCircleFilled(center, radius * GraphEditor.Zoom, color, segments);
    }

    public static void DrawEmptyCircle(float radius, uint color, int segments = 50)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + radius * GraphEditor.Zoom, cursorScreenPos.Y + radius);

        ImGui.GetWindowDrawList().AddCircle(center, radius * GraphEditor.Zoom, color, segments);
    }

    public static void DrawOutlineGlow(float radius, float force, uint color, int segments = 50)
    {
        Vector2 cursorScreenPos = ImGui.GetCursorScreenPos();
        Vector2 center = new Vector2(cursorScreenPos.X + radius * GraphEditor.Zoom, cursorScreenPos.Y + radius);

        float outerRadius = radius + radius * force;
        ImGui.GetWindowDrawList().AddCircleFilled(center, outerRadius * GraphEditor.Zoom, color, segments);
    }

    public static void NodeTooltip(string description)
    {
        if (ImGui.IsItemHovered(ImGuiHoveredFlags.None))
        {
            ImGui.BeginTooltip();
            ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
            ImGui.TextUnformatted(description);
            ImGui.PopTextWrapPos();
            ImGui.EndTooltip();
        }
    }

    public static void InOutTooltip(bool onoff, string description)
    {
        if (onoff)
        {
            ImGui.BeginTooltip();
            ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35.0f);
            ImGui.TextUnformatted(description);
            ImGui.PopTextWrapPos();
            ImGui.EndTooltip();
        }
    }

    public static Vector4 GetTypeColor(Type type)
    {
        switch (type)
        {
            case Type t when t == typeof(bool):
                return new Vector4(1, 0.00f, 0.00f, 1);

            case Type t when t == typeof(int):
                return new Vector4(0.11f, 0.90f, 0.69f, 1);

            case Type t when t == typeof(float):
                return new Vector4(0.66f, 1.00f, 0.31f, 1);

            case Type t when t == typeof(string):
                return new Vector4(0.98f, 0.00f, 0.82f, 1);

            case Type t when t == typeof(Vector3) || t == typeof(Vector2):
                return new Vector4(0.99f, 0.78f, 0.13f, 1);

            case Type t when t == typeof(GameObject):
                return new Vector4(0.75f, 0.47f, 0.77f, 1);

            case Type t when t == typeof(Transform):
                return new Vector4(0.36f, 0.30f, 0.77f, 1);
        }
        return new Vector4(0.00f, 0.66f, 0.95f, 1);
    }

    public static ImFontPtr Font14;
    public static ImFontPtr Font16;
    public static ImFontPtr Font18;
    public static ImFontPtr Font20;
    public static ImFontPtr Font22;
}
