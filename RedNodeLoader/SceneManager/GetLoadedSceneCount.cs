namespace RedNodeLoader.UnityNodes.SceneManager;

public class GetLoadedSceneCount : SonsNode
{
    [IsArgOut]
    public int SceneCount { get; set; }

    public override void Execute()
    {
        SceneCount = UnityEngine.SceneManagement.SceneManager.loadedSceneCount;
    }
}
