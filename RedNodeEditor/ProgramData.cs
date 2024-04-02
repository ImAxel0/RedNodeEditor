using System.IO.Pipes;
using System.Reflection;
using Veldrid.ImageSharp;
using static Octree;
using static RedNodeEditor.SonsNode;

namespace RedNodeEditor;

public class ProgramData
{
    public static readonly string AppVersion = "0.2.0";
    public static readonly string ProjectExtension = ".rproj";
    public static readonly string ModExtension = ".rmod";
    public static string ExeFolder = "";
    public static string ProjectsFolder = "";
    public static string ModsFolder = "";
    public static string GameModsFolder = "";
    public static bool OutputToGameFolder;

    public static IntPtr LogoImage;
    public static IntPtr BloodSplatterImg;

    public static void Initialize()
    {
        ExeFolder = Path.GetDirectoryName(Environment.ProcessPath);
        ProjectsFolder = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "Projects");
        ModsFolder = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "BuiltMods");
        GameModsFolder = Path.Combine(PathTools.GetGamePath(), "Mods\\RedNodeLoader\\Mods").Replace("SonsOfTheForest.exe", "");

        if (!Directory.Exists(ProjectsFolder))
            Directory.CreateDirectory(ProjectsFolder);

        if (!Directory.Exists(ModsFolder))
            Directory.CreateDirectory(ModsFolder);

        if (!string.IsNullOrEmpty(GameModsFolder) && !Directory.Exists(GameModsFolder))
            Directory.CreateDirectory(GameModsFolder);

        List<Type> nodeTypes = Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .Where(t => typeof(SonsNode).IsAssignableFrom(t) && t.IsClass && t.IsSubclassOf(typeof(SonsNode)))
                           .ToList();

#if DEBUG
        if (File.Exists(Path.Combine(ProjectsFolder, "Nodes.txt")))
        {
            File.Delete(Path.Combine(ProjectsFolder, "Nodes.txt"));
        }
#endif

        Logger.Append("Loading nodes...");
        foreach (Type nodeType in nodeTypes)
        {
            SonsNode node = Activator.CreateInstance(nodeType) as SonsNode;

#if DEBUG
            File.AppendAllText(Path.Combine(ProjectsFolder, "Nodes.txt"), node.Name + "\n");
#endif

            if (node != null)
            {
                if (node.NodeType == NodeTypes.Variable)
                    continue;

                foreach (NodeCategories enumValue in Enum.GetValues(typeof(NodeCategories)))
                {
                    if (node.NodeCategory == enumValue)
                    {
                        NodeList.CategoryNodesPair[node.NodeCategory].Add(node.Name, node);
                        Logger.Append($"    Loading [{node.Name}]");
                    }
                }
            }
        }
        Logger.Append($"All {nodeTypes.Count} nodes loaded!\n");

        ProjectData.CreateNewProject();

        //Task.Run(() => PipeManager.WaitForConnection());
    }
}
