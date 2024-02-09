using ImGuiNET;

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
