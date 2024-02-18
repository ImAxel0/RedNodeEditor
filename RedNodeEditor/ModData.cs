namespace RedNodeEditor;

public class ModData
{
    public string AppVersion { get; set; }
    public string ModName { get; set; }
    public string ModAuthor { get; set; }
    public string ModVersion { get; set; }
    public List<NodeConnection> OnInitializeMod { get; set; }
    public List<NodeConnection> OnSdkInitialized { get; set; }
    public List<NodeConnection> OnGameStart { get; set; }
    public List<NodeConnection> OnWorldUpdate { get; set; }
    public List<NodeConnection> OnUpdate { get; set; }
    public List<NodeConnection> OnFixedUpdate { get; set; }
    public List<NodeConnection> CustomEvents { get; set; }
}
