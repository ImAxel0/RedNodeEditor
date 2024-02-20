using SonsSdk;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace RedNodeLoader.EnvironmentNodes;

public class RemoveWaterfallsNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Scene sonsMain = SceneManager.GetSceneByName("Site02StreamsAndLakes");
        Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<GameObject> gameObjects = sonsMain.GetRootGameObjects();
        gameObjects.FirstWithName("Waterfalls").SetActive(!(bool)args[0]);
    }
}
