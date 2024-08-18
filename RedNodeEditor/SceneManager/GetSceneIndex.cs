using UnityEngine.SceneManagement;

namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetSceneIndex : SonsNode
{
    public GetSceneIndex()
    {
        Name = nameof(GetSceneIndex);
        Description = "Returns the index of the Scene in the Build Settings.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Scene), ArgName = nameof(Scene) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
