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
        "F11 = FULLSCREEN/WINDOWED\n" +
        "SHIFT+1 = VARIABLES TAB\n" +
        "SHIFT+2 = LOG TAB\n" +
        "------------------------------------------------\n" +
        "DELETE = DELETE NODE\n" +
        "CTRL+D = DUPLICATE NODE\n" +
        "CTRL+LMB+DRAG = CREATE COMMENT\n" +
        "CTRL+MOUSE WHEEL = ZOOM IN/OUT\n" +
        "F1 = QUICK NODE SELECTOR";

    public static void ShortcutListener()
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
                VariablesId = VariablesManager.VariablesId,
                Variables = VariablesManager.Variables
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
            ProjectDialogBuild.ShowDialog = true;
            return;
        }
        
        if (ImGui.GetIO().KeyShift && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey._1)))
            NodeList.SelectedOption = NodeList.Options.Variables;

        if (ImGui.GetIO().KeyShift && ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey._2)))
            NodeList.SelectedOption = NodeList.Options.Log;

        if (ImGui.IsKeyPressed(ImGui.GetKeyIndex(ImGuiKey.F11), false))
        {
            var windowsState = Program._window.WindowState == Veldrid.WindowState.BorderlessFullScreen ? Veldrid.WindowState.Normal : Veldrid.WindowState.BorderlessFullScreen;
            Program._window.WindowState = windowsState;              
        }
    }
}
