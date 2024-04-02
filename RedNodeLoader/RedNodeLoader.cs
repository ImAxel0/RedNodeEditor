using Pathfinding;
using RedLoader;
using RedLoader.Utils;
using RedNodeLoader.EventsNodes;
using RedNodeLoader.FlowNodes;
using SonsSdk;
using System.IO.Pipes;
using UnityEngine;
using Path = System.IO.Path;

namespace RedNodeLoader;

public class RedNodeLoader : SonsMod
{
    public static readonly string LoaderVersion = "0.2.0";

    /// <summary>
    /// all mods datas
    /// </summary>
    public static List<ModData> ModsData = new();

    /// <summary>
    /// all mods nodes id's and node instances
    /// </summary>
    public static Dictionary<string, SonsNode> IdNodePair { get; set; } = new();

    /// <summary>
    /// all mods custom events id's and event instances
    /// </summary>
    public static Dictionary<string, CustomEventNode> CustomEvents { get; set; } = new();

    public static List<GameObject> AssetBundleGameObjects { get; set; } = new();

    public static List<IfStatementNode> GetAllIfStatements(IfStatementNode topLevelIfStatement)
    {
        List<IfStatementNode> allIfStatements = new()
        {
            topLevelIfStatement
        };

        foreach (var node in topLevelIfStatement.TrueBranchNodes)
        {
            if (node.GetType() == typeof(IfStatementNode))
                allIfStatements.AddRange(GetAllIfStatements((IfStatementNode)node));
        }

        foreach (var node in topLevelIfStatement.FalseBranchNodes)
        {
            if (node.GetType() == typeof(IfStatementNode))
                allIfStatements.AddRange(GetAllIfStatements((IfStatementNode)node));
        }
        return allIfStatements;
    }

    static bool ShouldStorePair(SonsNode node)
    {
        return !node.GetType().CustomAttributes.Any(at => at.AttributeType == typeof(IsGetVariable));
    }

    public static List<string> ResolveConnections(NodeConnection connection)
    {
        List<string> stored = new();

        if (connection.Node.GetType() == typeof(IfStatementNode))
        {
            if (!IdNodePair.ContainsKey(connection.Node.Id))
            {
                IdNodePair.Add(connection.Node.Id, connection.Node);
                stored.Add(connection.Node.Id);
            }             

            var allIfNodes = GetAllIfStatements((IfStatementNode)connection.Node);

            foreach (var ifNode in allIfNodes)
            {
                ifNode.TrueBranchNodes.ForEach(node => {

                    if (!IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                    {
                        IdNodePair.Add(node.Id, node);
                        stored.Add(node.Id);
                    }
                        
                });

                ifNode.FalseBranchNodes.ForEach(node => {

                    if (!IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                    {
                        IdNodePair.Add(node.Id, node);
                        stored.Add(node.Id);
                    }                    
                });
            }
        }
        else if (!IdNodePair.ContainsKey(connection.Node.Id) && ShouldStorePair(connection.Node))
        {
            IdNodePair.Add(connection.Node.Id, connection.Node);
            stored.Add(connection.Node.Id);
        }

        return stored; 
    }

    protected override void OnEarlyInitializeMelon()
    {
        var modsFolder = Path.Combine(LoaderEnvironment.ModsDirectory, "RedNodeLoader", "Mods");
        if (!Directory.Exists(modsFolder))
            Directory.CreateDirectory(modsFolder);

        foreach (var mod in Directory.GetFiles(modsFolder).Where(file => Path.GetExtension(file) == ".rmod"))
            ModsData.Add(Serialization.GetModData(mod));
      
        ModsData.ForEach(modData =>
        {
            RLog.Msg(System.ConsoleColor.Cyan, $"{modData.ModName} v{modData.ModVersion}");
            RLog.Msg($"by {modData.ModAuthor}");
            RLog.Msg(System.ConsoleColor.DarkGray, $"Mod: {modData.ModName}.rmod");

            var editorVer = new Version(modData.AppVersion);
            var loaderVer = new Version(LoaderVersion);
            var result = editorVer.CompareTo(loaderVer);

            if (result > 0)
                RLog.Warning($"[{modData.ModName}] mod was built with a newer editor version ({editorVer}). You may need to update RedNodeLoader for it to work correctly");
            else if (result < 0)
                RLog.Warning($"[{modData.ModName}] mod was built with an older editor version ({editorVer}). The mod or some functionalities of it may not work correctly");

            modData.OnInitializeMod.ForEach(connection => {
                ResolveConnections(connection);
            });

            modData.OnSdkInitialized.ForEach(connection => {
                ResolveConnections(connection);
            });

            modData.OnGameStart.ForEach(connection => {
                ResolveConnections(connection);
            });

            modData.OnWorldUpdate.ForEach(connection => {
                ResolveConnections(connection);
            });

            modData.OnUpdate.ForEach(connection => {
                ResolveConnections(connection);
            });

            modData.OnFixedUpdate.ForEach(connection => {
                ResolveConnections(connection);
            });

            modData.OnInitializeMod.ForEach(connection => {
                GlobalEvents.OnPreModsLoaded.Subscribe(connection.Node.Execute);
            });
        });

        // populating all custom events for all mods
        foreach (var mod in ModsData)
        {
            PopulateCustomEvents(mod);
        }
    }

    public static Tuple<List<string>, List<string>> PopulateCustomEvents(ModData modData)
    {
        List<string> stored = new();
        List<string> storedCEvents = new();

        modData.CustomEvents.ForEach(cEvent => {

            // adding the custom event to the nodes dictionary
            if (!IdNodePair.ContainsKey(cEvent.Node.Id))
            {
                IdNodePair.Add(cEvent.Node.Id, cEvent.Node);
                stored.Add(cEvent.Node.Id);
            }
                
            // adding the custom event to the events dictionary
            var customEvent = (CustomEventNode)cEvent.Node;
            if (!CustomEvents.ContainsKey(customEvent.EventId))
            {
                CustomEvents.Add(customEvent.EventId, customEvent);
                storedCEvents.Add(customEvent.EventId);
            }              
            else          
                RLog.BigError("Error", $"{modData.ModName} mod contains a {nameof(CustomEventNode)} which has the same EventId as another mod.");            

            // handling custom event
            foreach (var node in customEvent.EventNodes)
            {
                if (node.GetType() == typeof(IfStatementNode))
                {
                    if (!IdNodePair.ContainsKey(node.Id))
                    {
                        IdNodePair.Add(node.Id, node);
                        stored.Add(node.Id);
                    }

                    var allIfNodes = GetAllIfStatements((IfStatementNode)node);

                    foreach (var ifNode in allIfNodes)
                    {
                        ifNode.TrueBranchNodes.ForEach(node => {

                            if (!IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                            {
                                IdNodePair.Add(node.Id, node);
                                stored.Add(node.Id);
                            }                              
                        });

                        ifNode.FalseBranchNodes.ForEach(node => {

                            if (!IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                            {
                                IdNodePair.Add(node.Id, node);
                                stored.Add(node.Id);
                            }                              
                        });
                    }
                }
                else if (!IdNodePair.ContainsKey(node.Id) && ShouldStorePair(node))
                {
                    IdNodePair.Add(node.Id, node);
                    stored.Add(node.Id);
                }                 
            }
        });

        return new Tuple<List<string>, List<string>>(stored, storedCEvents);
    }

    protected override void OnInitializeMod()
    {
        ModsData.ForEach(modData =>
        {
            modData.OnSdkInitialized.ForEach(connection => {
                SdkEvents.OnSdkInitialized.Subscribe(connection.Node.Execute);
            });
        });
    }

    protected override void OnSdkInitialized()
    {
        ModListUi.Create();
        PipeManager.WaitForConnection();

        ModsData.ForEach(modData =>
        {
            modData.OnGameStart.ForEach(connection => {
                SdkEvents.OnGameStart.Subscribe(connection.Node.Execute);
            });

            modData.OnWorldUpdate.ForEach(connection => {
                SdkEvents.OnInWorldUpdate.Subscribe(connection.Node.Execute);
            });

            modData.OnUpdate.ForEach(connection => {
                GlobalEvents.OnUpdate.Subscribe(connection.Node.Execute);
            });

            modData.OnFixedUpdate.ForEach(connection => {
                GlobalEvents.OnFixedUpdate.Subscribe(connection.Node.Execute);
            });
        });      
    }

    public static SonsNode GetNodeById(string id)
    {
        if (IdNodePair.TryGetValue(id, out SonsNode node))
        {
            return node;
        }
        return null;
    }

    public static CustomEventNode GetCustomEvent(string eventId)
    {
        if (CustomEvents.TryGetValue(eventId, out CustomEventNode customEvent))
        {
            return customEvent;
        }
        return null;
    }

    public static List<object> GetArgumentsOf(SonsNode thisNode)
    {
        List<object> args = new();

        int argIdx = 0;
        thisNode.ArgsIn.ForEach(argIn => {
            
            if (!argIn.HasConnection)
            {
                args.Add(thisNode.GetType().GetProperties().Where(p => p.DeclaringType == thisNode.GetType()).ElementAt(argIdx).GetValue(thisNode));
            }
            else
            {
                SonsNode node = GetNodeById(argIn.ReceiveFrom);
                var prop = node.GetType().GetProperties().Where(p => p.DeclaringType == node.GetType() 
                && p.GetCustomAttributes(typeof(IsArgOut), false).Any());

                args.Add(prop.ElementAt(argIn.ReceiveFromIndex).GetValue(node));
            }
            argIdx++;
        });

        return args;
    }

    public static void ReplaceIdNodePair<T1, T2>(Dictionary<T1, T2> d, T1 key, T1 newKey, T2 newValue)
    {
        if (d.ContainsKey(key))
        {
            d.Remove(key);
            d.Add(newKey, newValue);
        }
    }
}