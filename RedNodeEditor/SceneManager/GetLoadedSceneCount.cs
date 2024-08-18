namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetLoadedSceneCount : SonsNode
{
    public GetLoadedSceneCount()
    {
        Name = nameof(GetLoadedSceneCount);
        Description = "Returns the number of loaded Scenes.";
        NodeCategory = NodeCategories.Unity;

        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
