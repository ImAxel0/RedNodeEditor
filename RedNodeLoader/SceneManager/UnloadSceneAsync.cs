namespace RedNodeLoader.UnityNodes.SceneManager;

public class UnloadSceneAsync : SonsNode
{
    public string SceneName { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync((string)args[0]);
    }
}
