using IconFonts;
using ImGuiNET;

namespace RedNodeEditor;

public class ProjectDialogLoad
{
    public static bool ShowDialog;
    static string _searchBuffer = "";
    static bool _kbFocus = true;

    public static void Render()
    {
        if (!ShowDialog)
        {
            _searchBuffer = string.Empty;
            _kbFocus = true;
            return;
        }

        ImGui.OpenPopup($"Choose a mod project to load {FontAwesome6.FolderOpen}");
        ImGui.SetNextWindowSize(new(600, 400));
        ImGui.PushFont(Drawings.Font20);
        ImGui.BeginPopupModal($"Choose a mod project to load {FontAwesome6.FolderOpen}", ref ShowDialog, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDocking);
        ImGui.PopFont();

        ImGui.InputText($"Search project {FontAwesome6.MagnifyingGlass}", ref _searchBuffer, 1000);
        if (_kbFocus)
        {
            ImGui.SetKeyboardFocusHere(-1);
            _kbFocus = false;
        }
        ImGui.Separator();

        foreach (var file in Directory.GetFiles(ProgramData.ProjectsFolder))
        {
            if (Path.GetExtension(file) != ProgramData.ProjectExtension || !Path.GetFileName(file).ToLower().Contains(_searchBuffer.ToLower()))
                continue;

            var label = $"{Path.GetFileName(file)}\nCreated: {File.GetCreationTime(file)} || Last modified: {File.GetLastWriteTime(file)}";

            if (ImGui.Selectable(label, false, ImGuiSelectableFlags.AllowDoubleClick))
            {
                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    if (ProjectData.LoadProject(file))
                        ShowDialog = false;
                }             
            }
            ImGui.Dummy(new(0, 5));
        }
        ImGui.EndPopup();
    }
}
