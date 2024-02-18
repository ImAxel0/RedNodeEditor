using System.Xml.Serialization;
using System.Reflection;
using Vanara.PInvoke;
using RedNodeEditor.RedNodes;
using RedNodeEditor.EventNodes;
using RedNodeEditor.FlowNodes;

namespace RedNodeEditor;

public class ModBuilder
{
    static Dictionary<Type, List<NodeConnection>> BasePair = new()
    {
        { typeof(OnInitializeMod), new List<NodeConnection>() },
        { typeof(OnSdkInitialized), new List<NodeConnection>() },
        { typeof(OnGameStart), new List<NodeConnection>() },
        { typeof(OnWorldUpdate), new List<NodeConnection>() },
        { typeof(OnUpdate), new List<NodeConnection> () },
        { typeof(OnFixedUpdate), new List<NodeConnection> () },
        { typeof(CustomEventNode), new List<NodeConnection> () },
    };

    public static ModData MakeModData()
    {
        if (ProjectData.ProjectName == "unsaved")
        {
            Logger.Append("Error building the mod: project must be saved before building");
            User32.MessageBox(IntPtr.Zero, "Project must be saved before building", "Error building the mod", User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
            return null;
        }

        foreach (var connList in BasePair.Values)
            connList.Clear();

        PopulateConnections();
        if (!PopulateCustomEvents())
            return null;

        if (BasePair.Values.All(x => x.Count <= 1))
        {
            CleanForNextBuild();
            Logger.Append("Error building the mod: no base node was connected");
            User32.MessageBox(IntPtr.Zero, "No base node was connected", "Error building the mod", User32.MB_FLAGS.MB_ICONWARNING | User32.MB_FLAGS.MB_TOPMOST);
            return null;
        }

        ModData modData = new()
        {
            AppVersion = ProgramData.AppVersion,
            ModName = ProjectData.ProjectName.Replace(ProgramData.ProjectExtension, string.Empty),
            ModAuthor = "Axel",
            ModVersion = "1.0.0",
            OnInitializeMod = BasePair[typeof(OnInitializeMod)],
            OnSdkInitialized = BasePair[typeof(OnSdkInitialized)],
            OnGameStart = BasePair[typeof(OnGameStart)],
            OnWorldUpdate = BasePair[typeof(OnWorldUpdate)],
            OnUpdate = BasePair[typeof(OnUpdate)],
            OnFixedUpdate = BasePair[typeof(OnFixedUpdate)],
            CustomEvents = BasePair[typeof(CustomEventNode)]
        };
        return modData;
    }

    static bool PopulateCustomEvents()
    {
        var customEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CustomEventNode));
        var callCustomEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CallCustomEventNode));

        var result = ErrorSense.CheckCustomEvents(customEventNodes, callCustomEventNodes);

        if (result.Item1 == false)
        {
            User32.MessageBox(IntPtr.Zero, result.Item2, "Error building the mod", User32.MB_FLAGS.MB_TOPMOST | User32.MB_FLAGS.MB_ICONERROR);
            return false;
        }

        foreach (var customEvent in customEventNodes)
        {
            var cEvent = (CustomEventNode)customEvent;

            var nextInEvent = cEvent.Outputs[0].NextNode;

            if (nextInEvent == null) // if no node was connected to the event output
                continue;

            while (true)
            {
                cEvent.EventNodes.Add(nextInEvent);

                if (nextInEvent.GetType() == typeof(IfStatementNode))
                {
                    PopulateIfStatements(cEvent.GetType(), cEvent);
                    break;
                }
                nextInEvent = nextInEvent.Outputs[0].NextNode;
                if (nextInEvent == null)
                    break;
            }
            BasePair[typeof(CustomEventNode)].Add(new NodeConnection { Node = cEvent });
        }
        return true;
    }

    static void PopulateConnections()
    {
        foreach (var baseType in BasePair.Keys)
        {
            if (baseType == typeof(CustomEventNode))
                continue;

            PopulateConnectionsOf(baseType);
        }
    }

    static void PopulateConnectionsOf(Type baseType)
    {
        var baseNode = GraphEditor.GraphNodes.Find(node => node.GetType() == baseType);

        if (baseNode == null) 
            return;

        BasePair[baseType].Add(new NodeConnection { Node = baseNode });

        var next = baseNode.Outputs[0].NextNode;

        while (next != null)
        {
            if (next.GetType() == typeof(IfStatementNode))
            {
                BasePair[baseType].Add(new NodeConnection { Node = next });
                PopulateIfStatements(baseType, baseNode);
                break;
            }
            else
            {
                BasePair[baseType].Add(new NodeConnection { Node = next });
                next = next.Outputs[0].NextNode;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseType"></param>
    /// <param name="baseNode"> Mainly used to distinguish base nodes of the same type as CustomEvents</param>
    static void PopulateIfStatements(Type baseType, object baseNode)
    {
        var ifNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(IfStatementNode) && GraphEditor.FindBaseNodeOf(node).GetType() == baseType 
        && GraphEditor.FindBaseNodeOf(node) == (SonsNode)baseNode);

        foreach (var ifNode in ifNodes)
            PopulateIfStatement(ifNode);
    }

    static void PopulateIfStatement(SonsNode ifStatementNode)
    {
        IfStatementNode ifNode = (IfStatementNode)ifStatementNode;

        var nextTrue = ifNode.Outputs[0].NextNode;
        var nextFalse = ifNode.Outputs[1].NextNode;

        if (nextTrue != null)
        {
            while (true)
            {
                ifNode.TrueBranchNodes.Add(nextTrue);

                if (nextTrue.GetType() == typeof(IfStatementNode))
                    break;

                nextTrue = nextTrue.Outputs[0].NextNode;

                if (nextTrue == null)
                    break;
            }
        }

        if (nextFalse != null)
        {
            while (true)
            {
                ifNode.FalseBranchNodes.Add(nextFalse);

                if (nextFalse.GetType() == typeof(IfStatementNode))
                    break;

                nextFalse = nextFalse.Outputs[0].NextNode;

                if (nextFalse == null)
                    break;
            }
        }         
    }

    public static void SerializeModData(ModData modData)
    {
        var path = ProgramData.OutputToGameFolder ? ProgramData.GameModsFolder : ProgramData.ModsFolder;
        if (string.IsNullOrEmpty(path)) 
            path = ProgramData.ModsFolder;

        string modPath = Path.Combine(path, ProjectData.ProjectName.Replace(ProgramData.ProjectExtension, string.Empty) + ProgramData.ModExtension);

        try
        {
            using (FileStream fileStream = new FileStream(modPath, FileMode.Create))
            {
                var derived = GetDerivedTypes(typeof(SonsNode));
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ModData), derived);
                xmlSerializer.Serialize(fileStream, modData);
            }
            Logger.Append($"Mod built successfully at {modPath}");
            User32.MessageBox(IntPtr.Zero, $"Mod built successfully at {modPath}", "Build result", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_TOPMOST);
        }
        catch (Exception ex)
        {
            Logger.Append($"{ex.Message}");
            User32.MessageBox(IntPtr.Zero, $"{ex.Message}", "Build result", User32.MB_FLAGS.MB_OK | User32.MB_FLAGS.MB_ICONERROR | User32.MB_FLAGS.MB_TOPMOST);
        }
    
        CleanForNextBuild();
    }

    static void CleanForNextBuild()
    {
        var ifNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(IfStatementNode));
        foreach (var ifNode in ifNodes)
        {
            var node = (IfStatementNode)ifNode;
            node.TrueBranchNodes.Clear();
            node.FalseBranchNodes.Clear();
        }

        var customEventNodes = GraphEditor.GraphNodes.Where(node => node.GetType() == typeof(CustomEventNode));
        foreach (var customEventNode in customEventNodes)
        {
            var node = (CustomEventNode)customEventNode;
            node.EventNodes.Clear();
        }
    }

    static Type[] GetDerivedTypes(Type baseType)
    {
        List<Type> derivedTypes = new();
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            if (baseType.IsAssignableFrom(type) && type != baseType)
                derivedTypes.Add(type);
        }
        return derivedTypes.ToArray();
    }
}
