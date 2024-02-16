using IconFonts;
using ImGuiNET;
using Vanara.PInvoke;

namespace RedNodeEditor;

public class ProjectDialogSave
{
    public static bool ShowDialog;
    static string _projectNameBuffer = "";
    static bool _kbFocus = true;

    public static void Render()
    {
        if (!ShowDialog)
        {
            _projectNameBuffer = string.Empty;
            _kbFocus = true;
            return;
        }

        ImGui.OpenPopup($"Give a name to the mod project {FontAwesome6.SdCard}");
        ImGui.SetNextWindowSize(new(600, 400));
        ImGui.PushFont(Drawings.Font20);
        ImGui.BeginPopupModal($"Give a name to the mod project {FontAwesome6.SdCard}", ref ShowDialog, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDocking);
        ImGui.PopFont();

        ImGui.InputText("Project name", ref _projectNameBuffer, 1000);
        if (_kbFocus)
        {
            ImGui.SetKeyboardFocusHere(-1);
            _kbFocus = false;
        }
        //ImGui.SameLine();
        if (ImGui.Button($"Save {FontAwesome6.SdCard}", new(ImGui.GetContentRegionAvail().X, 50)))
        {
            if (string.IsNullOrEmpty(_projectNameBuffer))
            {
                User32.MessageBox(IntPtr.Zero, "Project name can't be empty", "Error saving the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
                return;
            }
            else if (_projectNameBuffer == "unsaved")
            {
                User32.MessageBox(IntPtr.Zero, "Illegal name. Project name can't be \"unsaved\"", "Error saving the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
                return;
            }

            ProjectData projectData = new()
            {
                GraphNodes = GraphEditor.GraphNodes,
                GraphComments = GraphEditor.GraphComments,
                VariablesId = VariablesManager.VariablesId,
                Variables = VariablesManager.Variables
            };
            var saved = ProjectData.SaveProjectAt(Path.Combine(ProgramData.ProjectsFolder, _projectNameBuffer + ProgramData.ProjectExtension), projectData);
            if (saved)
            {
                ShowDialog = false;
                _projectNameBuffer = string.Empty;
            }
        }

        ImGui.Separator();

        ImGui.PushFont(Drawings.Font18);
        ImGui.Text("Saved Projects:");
        ImGui.PopFont();

        foreach (var file in Directory.GetFiles(ProgramData.ProjectsFolder))
        {
            if (Path.GetExtension(file) != ProgramData.ProjectExtension)
                continue;

            var label = $"{Path.GetFileName(file)}\nCreated: {File.GetCreationTime(file)} || Last modified: {File.GetLastWriteTime(file)}";

            ImGui.TextDisabled(label);
            ImGui.Dummy(new(0, 5));
        }

        ImGui.EndPopup();
    }
}
