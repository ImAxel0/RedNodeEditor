using UnityEngine.SceneManagement;

namespace RedNodeEditor.UnityNodes.SceneManager;

public class GetSceneName : SonsNode
{
    public GetSceneName()
    {
        Name = nameof(GetSceneName);
        Description = "Returns the Scene name";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(Scene), ArgName = nameof(Scene) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
