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

        // project folder (Environment.ProcessPath\\Projects) + ProjectName = filePath

        string json = JsonConvert.SerializeObject(project, settings);
        var filePath = Path.Combine(ProgramData.ProjectsFolder, ProjectName);
        File.WriteAllText(filePath, json);
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
            ProjectName = Path.GetFileName(filePath);
            return true;
        }
        catch (Exception ex)
        {
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Error loading the project", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
            return false;
        }
    }

    public static void CreateNewProject()
    {
        GraphEditor.DeleteAllNodes();
        GraphEditor.GraphComments.Clear();

        GraphEditor.GraphNodes.Add(new OnInitializeMod() { Position = new(20, 100) });
        GraphEditor.GraphNodes.Add(new OnSdkInitialized() { Position = new(20, 400) });
        GraphEditor.GraphNodes.Add(new OnGameStart() { Position = new(20, 700) });
        GraphEditor.EditorScrollPos = Vector2.Zero;
        ProjectName = "unsaved";
    }
}
