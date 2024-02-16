using Newtonsoft.Json;
using RedNodeEditor.RedNodes;
using System.Numerics;
using Vanara.PInvoke;

namespace RedNodeEditor;

public class ProjectData
{
    public static string ProjectName = "unsaved";
    public List<SonsNode> GraphNodes = new();
    public List<GraphComment> GraphComments = new();
    public List<string> VariablesId = new();
    public Dictionary<string, Type> Variables = new();

    public static bool SaveProjectAt(string filePath, ProjectData project)
    {
        JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        string json = JsonConvert.SerializeObject(project, settings);

        try
        {
            File.WriteAllText(filePath, json);
            Logger.Append($"Project saved at: {filePath}");
        }
        catch (Exception ex)
        {
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error saving the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
            return false;
        }
        ProjectName = Path.GetFileName(filePath);
        return true;
    }

    public static void SaveProject(ProjectData project)
    {
        if (ProjectName == "unsaved")
        {
            ProjectDialogSave.ShowDialog = true;
            return;
        }

        JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ObjectCreationHandling = ObjectCreationHandling.Replace,
        };

        string json = JsonConvert.SerializeObject(project, settings);
        var filePath = Path.Combine(ProgramData.ProjectsFolder, ProjectName);

        try
        {
            File.WriteAllText(filePath, json);
            Logger.Append($"Project saved at: {filePath}");
        }
        catch (Exception ex)
        {
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error saving the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
        }
    }

    public static bool LoadProject(string filePath)
    {
        JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        string json = File.ReadAllText(filePath);

        try
        {
            var projectData = JsonConvert.DeserializeObject<ProjectData>(json, settings);
            GraphEditor.GraphNodes = projectData.GraphNodes;
            GraphEditor.GraphComments = projectData.GraphComments;
            VariablesManager.VariablesId = projectData.VariablesId;
            VariablesManager.Variables = projectData.Variables;
            ProjectName = Path.GetFileName(filePath);
            GraphEditor.EditorScrollPos = Vector2.Zero;
            Logger.Append($"Project loaded from: {filePath}");
        }
        catch (Exception ex)
        {
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error loading the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
            return false;
        }
        return true;
    }

    public static void CreateNewProject()
    {
        GraphEditor.DeleteAllNodes();
        GraphEditor.GraphComments.Clear();
        VariablesManager.VariablesId.Clear();
        VariablesManager.Variables.Clear();

        GraphEditor.GraphNodes.Add(new OnSdkInitialized() { Position = new(20, 100) });
        GraphEditor.GraphNodes.Add(new OnWorldUpdate() { Position = new(20, 400) });
        GraphEditor.GraphNodes.Add(new OnGameStart() { Position = new(20, 700) });
        GraphEditor.EditorScrollPos = Vector2.Zero;
        ProjectName = "unsaved";
    }
}
