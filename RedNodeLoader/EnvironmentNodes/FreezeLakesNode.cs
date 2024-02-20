using Sons.Atmosphere;
using UnityEngine.SceneManagement;
using UnityEngine;
using SonsSdk;

namespace RedNodeLoader.EnvironmentNodes;

public class FreezeLakesNode : SonsNode
{
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        FreezeLakes((bool)args[0]);
    }

    static void FreezeLakes(bool onoff)
    {
        GameObject lakes = SceneManager.GetSceneByName("Site02StreamsAndLakes").GetRootGameObjects().FirstWithName("Lakes");
        if (lakes)
            for (int i = 0; i < lakes.transform.GetChildCount(); i++)
            {
                Transform lake = lakes.transform.GetChild(i);
                FreezeWater freeze = lake.GetComponentInChildren<FreezeWater>();
                if (!freeze) { continue; }
                if (!freeze._forceFrozen && !freeze._neverFreeze)
                    freeze.Freeze(onoff);
            }
    }
}
