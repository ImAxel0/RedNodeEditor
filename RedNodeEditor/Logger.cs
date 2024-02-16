using IconFonts;
using ImGuiNET;
using System.Numerics;

namespace RedNodeEditor;

public class Logger
{
    public static string Content = "";

    public static void Append(string message)
    {
        Content += $"[{DateTime.Now.Hour}h:{DateTime.Now.Minute}m:{DateTime.Now.Second}s] {message}\n";
        File.WriteAllText(Path.Combine(ProgramData.ExeFolder, "Latest.log"), Content);
    }

    public static void ClearLog()
    {
        Content = string.Empty;
    }

    public static void Render()
    {
        ImGuiTheme.LoggerTheme();

        ImGui.PushFont(Drawings.Font20);
        ImGui.SeparatorText($"Log {FontAwesome6.EnvelopeOpenText}");
        ImGui.PopFont();

        ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.2f, 0.22f, 0.23f, 1);
        ImGui.BeginChild("LoggerWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);
        ImGui.BeginDisabled(true);
        ImGui.TextUnformatted(Content);
        ImGui.EndDisabled();
        ImGui.EndChild();

        ImGuiTheme.ApplyTheme();
    }
}
