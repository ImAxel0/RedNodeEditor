using ImGuiNET;

namespace RedNodeEditor;

public class ShortcutHelp
{
    public static string ShortcutInfo =
        "CTRL+N = NEW PROJECT\n" +
        "CTRL+O = OPEN PROJECT\n" +
        "CTRL+S = SAVE PROJECT\n" +
        "CTRL+A = SAVE PROJECT AT\n" +
        "CTRL+B = BUILD MOD\n" +
        "------------------------------------------------\n" +
        "DELETE = DELETE NODE\n" +
        "CTRL+D = DUPLICATE NODE\n" +
        "CTRL+LMB+DRAG = CREATE COMMENT\n" +
        "CTRL+MOUSE WHEEL = ZOOM IN/OUT\n" +
        "F1 = QUICK NODE SELECTOR";

    public static void ShortcutLisener()
    {
        if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.O)))
        {
            ProjectDialogLoad.ShowDialog = true;
            return;
        }

        if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.A)))
        {
            ProjectDialogSave.ShowDialog = true;
            return;
        }

        if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.S)))
        {
            ProjectData projectData = new()
            {
                GraphNodes = GraphEditor.GraphNodes,
                GraphComments = GraphEditor.GraphComments,
            };
            ProjectData.SaveProject(projectData);
            return;
        }

        if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.N)))
        {
            ProjectData.CreateNewProject();
            return;
        }

        if (ImGui.GetIO().KeyCtrl && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.B)))
        {
            ModData modData = ModBuilder.MakeModData();
            if (modData != null)
            {
                ModBuilder.SerializeModData(modData);
            }
            return;
        }
    }
}
