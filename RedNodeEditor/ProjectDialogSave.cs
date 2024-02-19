using IconFonts;
using ImGuiNET;
using System.Numerics;
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
        ImGui.SetNextWindowPos(ImGui.GetIO().DisplaySize / 2 - new Vector2(300, 200));
        ImGui.PushFont(Drawings.Font20);
        ImGui.BeginPopupModal($"Give a name to the mod project {FontAwesome6.SdCard}", ref ShowDialog, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove);
        ImGui.PopFont();

        ImGui.BeginChild("SavingDialogTopBar", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 70), ImGuiChildFlags.Border);

        ImGui.InputText("Project name", ref _projectNameBuffer, 1000);
        if (_kbFocus)
        {
            ImGui.SetKeyboardFocusHere(-1);
            _kbFocus = false;
        }

        if (ImGui.Button($"Save", new(ImGui.GetContentRegionAvail().X, 25)))
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
        ImGui.EndChild();

        ImGui.BeginChild("SavingDialogTable", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

        if (!ShowDialog) // prevents crash
            return;

        ImGui.BeginTable("SavedProjectsTable", 3, ImGuiTableFlags.Borders);
        ImGui.TableSetupColumn("Name");
        ImGui.TableSetupColumn("Creation");
        ImGui.TableSetupColumn("Last modified");
        ImGui.TableHeadersRow();

        foreach (var file in Directory.GetFiles(ProgramData.ProjectsFolder))
        {
            if (Path.GetExtension(file) != ProgramData.ProjectExtension)
                continue;

            ImGui.TableNextRow();
            ImGui.TableSetColumnIndex(0);
            ImGui.TextDisabled(Path.GetFileName(file));

            ImGui.TableSetColumnIndex(1);
            ImGui.TextDisabled(File.GetCreationTime(file).ToString());

            ImGui.TableSetColumnIndex(2);
            ImGui.TextDisabled(File.GetLastWriteTime(file).ToString());
        }
        ImGui.EndTable();
        ImGui.EndChild();

        ImGui.EndPopup();
    }
}
