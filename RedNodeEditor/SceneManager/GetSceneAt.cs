namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetSceneAt : SonsNode
{
    public int Index { get; set; }

    public GetSceneAt()
    {
        Name = nameof(GetSceneAt);
        Description = "Get the Scene at index in the SceneManager's list of loaded Scenes.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Index) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.SceneManagement.Scene) });
    }
}
