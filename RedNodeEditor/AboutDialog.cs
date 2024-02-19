using IconFonts;
using ImGuiNET;
using System.Diagnostics;
using System.Numerics;

namespace RedNodeEditor;

public class AboutDialog
{
    public static bool ShowDialog;

    public static void Render()
    {
        if (!ShowDialog)
            return;

        ImGuiTheme.ImGuiStyle.WindowRounding = 5;
        ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.PopupBg] = new Vector4(0.12f, 0.12f, 0.12f, 1f);
        ImGuiTheme.ImGuiStyle.Colors[(int)ImGuiCol.Button] = Drawings.Colors.SelectedNodeColor;

        ImGui.OpenPopup($"About");
        ImGui.SetNextWindowSize(new(600, 400));
        ImGui.SetNextWindowPos(ImGui.GetIO().DisplaySize / 2 - new Vector2(300, 200));
        ImGui.PushFont(Drawings.Font20);
        ImGui.BeginPopupModal($"About", ref ShowDialog, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove);
        ImGui.PopFont();

        ImGui.GetWindowDrawList().AddImage(ProgramData.BloodSplatterImg, ImGui.GetWindowPos(), ImGui.GetWindowPos() + ImGui.GetWindowSize(), 
            Vector2.Zero, Vector2.One, ImGui.GetColorU32(new Vector4(1, 0, 0.28f, 0.5f)));

        ImGui.SetCursorPosX(ImGui.GetWindowSize().X / 2 - 125);

        if (ImGui.ImageButton("LogoButton", ProgramData.LogoImage, new(250, 250), Vector2.Zero, Vector2.One, new Vector4(0.11f, 0.10f, 0.10f, 1f)))
        {
            Process.Start(new ProcessStartInfo("https://github.com/ImAxel0/RedNodeEditor") { UseShellExecute = true });
        }
        if (ImGui.IsItemHovered())
            ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);

        ImGui.BeginChild("AppInfoWindow", ImGui.GetContentRegionAvail(),  ImGuiChildFlags.Border);

        ImGui.PushFont(Drawings.ForestFont);
        ImGui.SetCursorPos(ImGui.GetWindowSize() / 2 - ImGui.CalcTextSize($"RedNodeEditor v{ProgramData.AppVersion}") / 2);
        ImGui.TextColored(Drawings.Colors.SelectedNodeColor, $"Red Node Editor v {ProgramData.AppVersion}");
        ImGui.PopFont();

        ImGui.PushFont(Drawings.Font20);
        ImGui.SetCursorPos(ImGui.GetWindowSize() - ImGui.CalcTextSize("Developed by Im-_-Axel") - new Vector2(20, 0));
        ImGui.TextDisabled("Developed by Im-_-Axel");
        ImGui.PopFont();

        ImGui.EndChild();

        ImGui.EndPopup();

        ImGuiTheme.ApplyTheme();
    }
}
