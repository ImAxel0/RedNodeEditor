namespace RedNodeEditor.UnityNodes.SceneManager;

public class UnloadSceneAsync : SonsNode
{
    public string SceneName { get; set; }

    public UnloadSceneAsync()
    {
        Name = nameof(UnloadSceneAsync);
        Description = "Destroys all GameObjects associated with the given Scene and removes the Scene from the SceneManager.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
    }
}
