using SonsSdk;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace RedNodeLoader.EnvironmentNodes;

public class RemoveOceanNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Scene sonsMain = SceneManager.GetSceneByName("SonsMain");
        Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<GameObject> gameObjects = sonsMain.GetRootGameObjects();
        gameObjects.FirstWithName("OceanZone").SetActive(!(bool)args[0]);
        gameObjects.FirstWithName("Atmosphere").transform.Find("CrestOcean").gameObject.SetActive(!(bool)args[0]);
    }
}
