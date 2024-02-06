using ImGuiNET;

namespace RedNodeEditor;

public class Logger
{
    public static string Content = "";

    public static void Append(string message)
    {
        Content += message + "\n";
    }

    public static void ClearLog()
    {
        Content = string.Empty;
    }

    public static void Render()
    {
        ImGuiTheme.LoggerTheme();

        ImGui.PushFont(Drawings.Font20);
        ImGui.SeparatorText("Log");
        ImGui.PopFont();

        ImGui.BeginChild("LoggerWindow", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);
        ImGui.BeginDisabled(true);
        ImGui.TextUnformatted(Content);
        ImGui.EndDisabled();
        ImGui.EndChild();

        ImGuiTheme.ApplyTheme();
    }
}
