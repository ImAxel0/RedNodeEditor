namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetActiveScene : SonsNode
{
    public GetActiveScene()
    {
        Name = nameof(GetActiveScene);
        Description = "Gets the currently active Scene.";
        NodeCategory = NodeCategories.Unity;

        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.SceneManagement.Scene) });
    }
}
