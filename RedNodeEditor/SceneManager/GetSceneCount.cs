namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetSceneCount : SonsNode
{
    public GetSceneCount()
    {
        Name = nameof(GetSceneCount);
        Description = "Returns the current number of Scenes.";
        NodeCategory = NodeCategories.Unity;

        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
