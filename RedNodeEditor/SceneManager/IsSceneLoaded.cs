using UnityEngine.SceneManagement;

namespace RedNodeEditor.UnityNodes.SceneManager;

public class IsSceneLoaded : SonsNode
{
    public IsSceneLoaded()
    {
        Name = nameof(IsSceneLoaded);
        Description = "IsLoaded is set to true after loading has completed and objects have been enabled.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Scene), ArgName = nameof(Scene) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
