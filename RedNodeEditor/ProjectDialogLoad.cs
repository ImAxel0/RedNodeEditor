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

        ImGui.BeginChild("LoadingDialogTopBar", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 40), ImGuiChildFlags.Border);

        ImGui.InputText($"Search project {FontAwesome6.MagnifyingGlass}", ref _searchBuffer, 1000);
        if (_kbFocus)
        {
            ImGui.SetKeyboardFocusHere(-1);
            _kbFocus = false;
        }

        ImGui.EndChild();

        ImGui.BeginChild("LoadingDialogTable", ImGui.GetContentRegionAvail(), ImGuiChildFlags.Border);

        if (!ShowDialog) // prevents crash
            return;

        ImGui.BeginTable("LoadingSavedProjectsTable", 3, ImGuiTableFlags.Borders);
        ImGui.TableSetupColumn("Name");
        ImGui.TableSetupColumn("Creation");
        ImGui.TableSetupColumn("Last modified");
        ImGui.TableHeadersRow();

        foreach (var file in Directory.GetFiles(ProgramData.ProjectsFolder))
        {
            if (Path.GetExtension(file) != ProgramData.ProjectExtension || !Path.GetFileName(file).ToLower().Contains(_searchBuffer.ToLower()))
                continue;

            ImGui.TableNextRow();
            ImGui.TableSetColumnIndex(0);
            if (ImGui.Selectable(Path.GetFileName(file), false, ImGuiSelectableFlags.AllowDoubleClick))
            {
                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    if (ProjectData.LoadProject(file))
                        ShowDialog = false;
                }
            }

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
