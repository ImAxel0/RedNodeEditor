namespace RedNodeLoader.UnityNodes.SceneManager;

public class GetSceneCount : SonsNode
{
    [IsArgOut]
    public int SceneCount { get; set; }

    public override void Execute()
    {
        SceneCount = UnityEngine.SceneManagement.SceneManager.sceneCount;
    }
}
